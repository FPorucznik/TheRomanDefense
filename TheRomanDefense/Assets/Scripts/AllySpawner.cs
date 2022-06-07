using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject allyPrefab;
    private List<int> availablePoints;
    public int current = 0;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        availablePoints = new List<int>
        {
            0,1,2,3,4
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int index = rand.Next(availablePoints.Count);
        GameObject soldier = Instantiate(allyPrefab, spawnPoints[availablePoints[index]].position, transform.rotation);
        soldier.GetComponent<Soldier>().point = availablePoints[index];
        availablePoints.RemoveAt(index);
    }

    public bool UpdateAllies()
    {
        if(current < 5)
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

    public void UpdateAvailablePoints(int point)
    {
        availablePoints.Add(point);
        availablePoints.Sort();
    }
}
