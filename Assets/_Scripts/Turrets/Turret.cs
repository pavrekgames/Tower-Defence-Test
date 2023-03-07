using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [Header("Build Attributes")]
    protected TurretFactory turretFactory;
    public TurretData turretData;

    [Header("Turret Attributes")]
    [SerializeField] protected Transform target;
    [SerializeField] protected GameObject partToRotate;
    public float range;
    public int cost;

    [Header("Bullet Attributes")]
    [SerializeField] protected Transform placeForBullet;
    public GameObject bullet;
    public Transform bulletTarget;

    public abstract void Shoot();
    public abstract void LookAtTarget();

    private void Start()
    {
        range = turretData.range;
        cost = turretData.cost;
    }
    protected void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distancToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distancToEnemy < shortestDistance)
            {
                shortestDistance = distancToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            Shoot();
        }
        else
        {
            target = null;
        }
    }

    protected void DecorateBullet(GameObject bullet)
    {
        Bullet currentBullet = bullet.GetComponent<Bullet>();
        currentBullet.damage = turretData.damage;
        currentBullet.speed = turretData.bulletSpeed;
    }
}
