using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarEnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] enemyPrefabs;
    WarEnemyBase baseObj;
    private float repeatRate;
    private int enemyType;

    // Start is called before the first frame update
    void Start()
    {
        enemyType = Random.Range(0, 100);
        repeatRate = 3f;
        baseObj = FindObjectOfType<WarEnemyBase>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnLightSoldier()
    {
        if (baseObj.gold >= 10)
        {
            Instantiate(enemyPrefabs[0], spawnPoint.position, transform.rotation);
            baseObj.gold -= 10;
            enemyType = Random.Range(0, 100);
        }
    }

    public void SpawnHeavySoldier()
    {
        if (baseObj.gold >= 20)
        {
            Instantiate(enemyPrefabs[1], spawnPoint.position, transform.rotation);
            baseObj.gold -= 20;
            enemyType = Random.Range(0, 100);
        }
    }

    private IEnumerator Spawn()
    {
        while (baseObj.gold >= 0)
        {
            if (enemyType >= 50)
            {
                SpawnLightSoldier();
            }
            else
            {
                SpawnHeavySoldier();
            }
            yield return new WaitForSeconds(repeatRate);
        }
    }
}
