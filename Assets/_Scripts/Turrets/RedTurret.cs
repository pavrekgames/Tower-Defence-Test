using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTurret : Turret
{

    void Start()
    {
        turretFactory = TurretFactory.instance;
        turretData = turretFactory.currentRedTurretUpgrade;
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
    }

    public override void Shoot()
    {
        GameObject newBullet = BulletsObjectPool.instance.GetPooledObject();
        newBullet.transform.position = placeForBullet.transform.position;
        newBullet.transform.rotation = placeForBullet.transform.rotation;
        DecorateBullet(newBullet);
        newBullet.SetActive(true);
        newBullet.GetComponent<Bullet>().target = target;
    }
}
