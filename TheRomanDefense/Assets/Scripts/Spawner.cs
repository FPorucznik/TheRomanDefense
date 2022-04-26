using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private void Start()
    {
        InvokeRepeating("Spawn", 2.0f, 0.5f);
    }

    private void Spawn()
    {
        int randPoint = Random.Range(0, spawnPoints.Length);
        int randEnemy = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randPoint].position, transform.rotation);
    }
}
