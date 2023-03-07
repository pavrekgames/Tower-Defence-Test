using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFactory : MonoBehaviour
{
    public static TurretFactory instance;

    public GameObject[] turrets;
    public GameObject currentTurret;
    public Node selectedNode;

    public TurretData currentRedTurretUpgrade;
    public TurretData currentGreenTurretUpgrade;

    private void Awake()
    {
        if (instance == null) { instance = this; } else { Destroy(gameObject); }
    }
    private void Start()
    {
        currentTurret = turrets[0];
    }
    public void ChooseRedTurret()
    {
        currentTurret = turrets[0];
        currentTurret.GetComponent<Turret>().turretData = currentRedTurretUpgrade;
    }

    public void ChooseGreenTurret()
    {
        currentTurret = turrets[1];
        currentTurret.GetComponent<Turret>().turretData = currentGreenTurretUpgrade;
    }
}
