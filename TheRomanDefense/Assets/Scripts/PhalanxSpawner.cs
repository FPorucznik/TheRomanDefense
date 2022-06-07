using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhalanxSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject prefab;

    public void Spawn()
    {
        Instantiate(prefab, spawnPoint.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
