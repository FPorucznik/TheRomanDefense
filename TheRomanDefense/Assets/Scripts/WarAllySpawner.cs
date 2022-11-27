using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarAllySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] allyPrefabs;
    public Button spawnLightBtn;
    public Button spawnHeavyBtn;

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
        Instantiate(allyPrefabs[0], spawnPoint.position, transform.rotation);
        spawnLightBtn.interactable = true;
        spawnHeavyBtn.interactable = true;
    }

    private void SpawnHeavySoldierInstance()
    {
        Instantiate(allyPrefabs[1], spawnPoint.position, transform.rotation);
        spawnHeavyBtn.interactable = true;
        spawnLightBtn.interactable = true;
    }

}
