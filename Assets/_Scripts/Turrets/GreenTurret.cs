using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTurret : Turret
{
    [SerializeField] protected GameObject partToRotate2;
    [SerializeField] protected Transform placeForBullet2;

    void Start()
    {
        turretFactory = TurretFactory.instance;
        turretData = turretFactory.currentGreenTurretUpgrade;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void Update()
    {
        if (target == null) return;

        LookAtTarget();
    }

    public override void LookAtTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
        partToRotate2.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    public override void Shoot()
    {
        GameObject newBullet = BulletsObjectPool.instance.GetPooledObject();
        SetBullet(newBullet, placeForBullet);

        GameObject newBullet2 = BulletsObjectPool.instance.GetPooledObject();
        SetBullet(newBullet2, placeForBullet2);

    }

    void SetBullet(GameObject bullet, Transform placeForBullet)
    {
        bullet.transform.position = placeForBullet.transform.position;
        bullet.transform.rotation = placeForBullet.transform.rotation;
        DecorateBullet(bullet);
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().target = target;
    }
}
