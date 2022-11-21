using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarUpgrades : MonoBehaviour
{
    private WarAllyBase baseObj;
    private WarAllySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        baseObj = FindObjectOfType<WarAllyBase>();
        spawner = FindObjectOfType<WarAllySpawner>();
    }

    public void SpawnLightSoldier()
    {
        if (baseObj.gold >= 10)
        {
            spawner.SpawnLightSoldier();
            baseObj.gold -= 10;
        }
    }

    public void SpawnHeavySoldier()
    {
        if (baseObj.gold >= 20)
        {
            spawner.SpawnHeavySoldier();
            baseObj.gold -= 20;
        }
    }
}
