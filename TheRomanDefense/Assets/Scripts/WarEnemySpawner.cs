using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarEnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    WarEnemyBase baseObj;
    private float repeatRate;
    private int enemyType;
    public bool isFortification;

    // Start is called before the first frame update
    void Start()
    {
        enemyType = Random.Range(0, 100);
        repeatRate = 7f;
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
            Instantiate(enemyPrefabs[0], spawnPoints[0].position, transform.rotation);
            baseObj.gold -= 10;
            enemyType = Random.Range(0, 100);
        }
    }

    public void SpawnHeavySoldier()
    {
        if (baseObj.gold >= 20)
        {
            Instantiate(enemyPrefabs[1], spawnPoints[0].position, transform.rotation);
            baseObj.gold -= 20;
            enemyType = Random.Range(0, 100);
        }
    }

    public void SpawnFortification()
    {
        if (baseObj.gold >= 80)
        {
            GameObject obj = Instantiate(enemyPrefabs[2], spawnPoints[1].position, transform.rotation);
            baseObj.gold -= 80;
            isFortification = true;
            obj.layer = 15;
            Fortification fortification = obj.GetComponent<Fortification>();
            fortification.tag = "enemyFortification";
        }
    }

    public void FixBase()
    {
        if(baseObj.gold >= 30)
        {
            baseObj.health = 100f;
            baseObj.gold -= 30;
        }
    }

    private IEnumerator Spawn()
    {
        while (baseObj.gold >= 0)
        {
            int fortificationBuy = Random.Range(1, 4);
            if (fortificationBuy == 3 && !isFortification)
            {
                SpawnFortification();
            }

            int fixBase = Random.Range(1, 3);
            if (fixBase == 2 && baseObj.health <= 50)
            {
                FixBase();
            }

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
