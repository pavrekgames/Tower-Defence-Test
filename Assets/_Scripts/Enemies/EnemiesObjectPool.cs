using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesObjectPool : MonoBehaviour
{
    public static EnemiesObjectPool instance;

    [Header("Pooled Objects List")]
    public List<GameObject> simpleEnemies = new List<GameObject>();
    public List<GameObject> armoredEnemies = new List<GameObject>();

    [Header("Poole Objects Prefabs")]
    public GameObject simpleEnemyToPool;
    public GameObject armoredEnemyToPool;

    [Header("Other")]
    public int enemyAmount;
    public Transform enemiesParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        CreateEnemies(simpleEnemies, simpleEnemyToPool);
        CreateEnemies(armoredEnemies, armoredEnemyToPool);
    }

    void CreateEnemies(List<GameObject> enemies, GameObject enemyToPool)
    {
        GameObject newEnemy;

        for (int i = 0; i < enemyAmount; i++)
        {
            newEnemy = Instantiate(enemyToPool, enemiesParent);
            newEnemy.SetActive(false);
            enemies.Add(newEnemy);
        }
    }

    public GameObject GetSimpleEnemy()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            if (!simpleEnemies[i].activeInHierarchy)
            {
                return simpleEnemies[i];
            }
        }
        return null;
    }

    public GameObject GetArmoredEnemy()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            if (!armoredEnemies[i].activeInHierarchy)
            {
                return armoredEnemies[i];
            }
        }
        return null;
    }

}
