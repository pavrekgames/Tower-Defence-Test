using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredEnemy : Enemy
{
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        float distance = Vector3.Distance(transform.position, target.position);

        MoveEnemy(direction);
        GetNextPoint(distance);
        EnemyDeath();
        HealthBar();
    }
}
