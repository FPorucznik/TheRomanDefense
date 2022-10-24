using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject strongEnemy;
    public int wave;
    private int amount;
    private int strongAmount;
    private int current;
    public Text waveText;

    private void Start()
    {
        wave = 1;
        amount = 10;
        strongAmount = 1;
        current = 0;

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(current < amount)
        {
            int randPoint = Random.Range(0, spawnPoints.Length);
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            yield return new WaitForSeconds(0.8f);

            if(current < amount - strongAmount)
            {
                Instantiate(enemyPrefabs[randEnemy], spawnPoints[randPoint].position, transform.rotation);
                current++;
            }
            else
            {
                Instantiate(strongEnemy, spawnPoints[randPoint].position, transform.rotation);
                strongAmount--;
                current++;
            }
        }

        wave++;
        strongAmount = wave;
        amount = wave * 10;
        current = 0;
        yield return new WaitForSeconds(10);
        waveText.text = wave.ToString();
        StopCoroutine(Spawn());
        StartCoroutine(Spawn());
    }

}
