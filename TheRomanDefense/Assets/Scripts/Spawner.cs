using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int randPoint = Random.Range(0, spawnPoints.Length);
            int randEnemy = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randPoint].position, transform.rotation);
        }
    }
}
