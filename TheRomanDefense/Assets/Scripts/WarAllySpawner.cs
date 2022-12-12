using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarAllySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] allyPrefabs;
    public Button spawnLightBtn;
    public Button spawnHeavyBtn;
    public Button spawnDefenseBtn;

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
        spawnLightBtn.interactable = false;
        spawnHeavyBtn.interactable = false;
        Invoke("SpawnLightSoldierInstance", 2f);
    }

    public void SpawnHeavySoldier()
    {
        spawnHeavyBtn.interactable = false;
        spawnLightBtn.interactable = false;
        Invoke("SpawnHeavySoldierInstance", 4f);
    }
    private void SpawnLightSoldierInstance()
    {
        Instantiate(allyPrefabs[0], spawnPoints[0].position, transform.rotation);
        spawnLightBtn.interactable = true;
        spawnHeavyBtn.interactable = true;
    }

    private void SpawnHeavySoldierInstance()
    {
        Instantiate(allyPrefabs[1], spawnPoints[0].position, transform.rotation);
        spawnHeavyBtn.interactable = true;
        spawnLightBtn.interactable = true;
    }

    public void SpawnFortification()
    {
        spawnDefenseBtn.interactable = false;
        GameObject obj = Instantiate(allyPrefabs[2], spawnPoints[1].position, transform.rotation);
        obj.layer = 14;
        Fortification fortification = obj.GetComponent<Fortification>();
        fortification.tag = "allyFortification";
    }

}
