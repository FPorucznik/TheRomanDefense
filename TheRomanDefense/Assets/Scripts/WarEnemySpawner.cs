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
        //assign necessary values for random enemy spawn
        enemyType = Random.Range(0, 12);
        repeatRate = 10f;
        baseObj = FindObjectOfType<WarEnemyBase>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //below methods spawn enemy unit object and set a new random value for decision making
    public void SpawnLightSoldier()
    {
        if (baseObj.gold >= 10)
        {
            Instantiate(enemyPrefabs[0], spawnPoints[0].position, transform.rotation);
            baseObj.gold -= 10;
            enemyType = Random.Range(0, 12);
        }
    }

    public void SpawnHeavySoldier()
    {
        if (baseObj.gold >= 50)
        {
            Instantiate(enemyPrefabs[1], spawnPoints[0].position, transform.rotation);
            baseObj.gold -= 50;
            enemyType = Random.Range(0, 12);
        }
    }

    //spawns enemy fortification object and makes spawning another one impossible until it is destroyed using isFortification boolean
    public void SpawnFortification()
    {
        if (baseObj.gold >= 60)
        {
            GameObject obj = Instantiate(enemyPrefabs[2], spawnPoints[1].position, transform.rotation);
            baseObj.gold -= 60;
            isFortification = true;
            obj.layer = 15;
            Fortification fortification = obj.GetComponent<Fortification>();
            fortification.tag = "enemyFortification";
        }
    }

    //restores enemy base health
    public void FixBase()
    {
        if(baseObj.gold >= 30)
        {
            baseObj.health = 100f;
            baseObj.gold -= 30;
        }
    }

    //method that runs from the start of the game every 'repeatRate' seconds
    private IEnumerator Spawn()
    {
        while (baseObj.gold >= 0)
        {
            //generates random number and if it matches then tries to spawn fortification
            int fortificationBuy = Random.Range(1, 5);
            if (fortificationBuy == 3 && !isFortification)
            {
                SpawnFortification();
            }

            //generates random number and if it matches then tries to fix base
            int fixBase = Random.Range(1, 3);
            if (fixBase == 2 && baseObj.health <= 50)
            {
                FixBase();
            }

            //depending on enemyType random value, decides to spawn a light soldier or heavy soldier
            if (enemyType >= 5)
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
