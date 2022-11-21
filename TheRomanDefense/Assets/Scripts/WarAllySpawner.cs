using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarAllySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] allyPrefabs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnLightSoldier()
    {
        Instantiate(allyPrefabs[0], spawnPoint.position, transform.rotation);
    }

    public void SpawnHeavySoldier()
    {
        Instantiate(allyPrefabs[1], spawnPoint.position, transform.rotation);
    }
}
