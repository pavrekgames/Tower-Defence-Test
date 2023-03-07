using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret", menuName = "Turret")]
public class TurretData : ScriptableObject
{
    public int level;
    public string turretName;
    public int cost;
    public int damage;
    public float range;
    public float bulletSpeed;
    public int upgradeCost;

}
