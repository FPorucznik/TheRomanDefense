using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHelperSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject shooterPrefab;
    public int current = 0;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        if(current == 1)
        {
            GameObject soldier = Instantiate(shooterPrefab, spawnPoints[0].position, transform.rotation);
        }
        else if(current == 2)
        {
            GameObject soldier = Instantiate(shooterPrefab, spawnPoints[1].position, transform.rotation);
        }
        
    }

    public bool UpdateAllies()
    {
        if (current < 2)
        {
            current++;
            Spawn();
            return true;
        }
        else
        {
            return false;
        }
    }

}
