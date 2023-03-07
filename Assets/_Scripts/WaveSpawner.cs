using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class WaveSpawner : MonoBehaviour
{
    [Header("Spawn points")]
    [SerializeField] private Transform spawnPoint;

    [Header("Wave Attributes")]
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float simpleCountdown = 0;
    [SerializeField] private float armoredCountdown = 5;
    [SerializeField] private int enemiesCount;

    public static event Action OnSpawnedEnemy;
    void Update()
    {
        if (simpleCountdown <= 0) { StartCoroutine(SpawnSimpleEnemy()); } else { simpleCountdown -= Time.deltaTime; }
        if (armoredCountdown <= 0) { StartCoroutine(SpawnArmoredEnemy()); } else { armoredCountdown -= Time.deltaTime; }
    }

    IEnumerator SpawnSimpleEnemy()
    {
        simpleCountdown = timeBetweenWaves;
        timeBetweenWaves = UnityEngine.Random.Range(1, 6);
        enemiesCount = UnityEngine.Random.Range(3, 6);

        for (int i = 0; i < enemiesCount; i++)
        {
            SpawnEnemy(EnemiesObjectPool.instance.GetSimpleEnemy());
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SpawnArmoredEnemy()
    {
        armoredCountdown = UnityEngine.Random.Range(5, 10);

        for (int i = 0; i < 1; i++)
        {
            SpawnEnemy(EnemiesObjectPool.instance.GetArmoredEnemy());
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject newEnemy = enemy;
        newEnemy.transform.position = spawnPoint.transform.position;
        newEnemy.transform.rotation = spawnPoint.transform.rotation;
        newEnemy.SetActive(true);
        GameManager.enemiesAmount++;
        OnSpawnedEnemy?.Invoke();
    }
}
