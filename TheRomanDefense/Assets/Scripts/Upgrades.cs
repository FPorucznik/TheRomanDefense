using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Base baseObj;
    private Shooting shootingObj;
    private AllySpawner spawner;
    private ShooterHelperSpawner spawnerShooters;
    private Barrage spawnerBarrage;
    private PhalanxSpawner spawnerPhalanx;
    //public Transform[] barragePoints;

    // Start is called before the first frame update
    void Start()
    {
        baseObj = FindObjectOfType<Base>();
        shootingObj = FindObjectOfType<Shooting>();
        spawner = FindObjectOfType<AllySpawner>();
        spawnerShooters = FindObjectOfType<ShooterHelperSpawner>();
        spawnerBarrage = FindObjectOfType<Barrage>();
        spawnerPhalanx = FindObjectOfType<PhalanxSpawner>();
    }

    public void FixWall()
    {
        if(baseObj.gold >= 10)
        {
            baseObj.health = 100f;
            baseObj.gold -= 10;
        }
    }

    public void IncreaseSpeed()
    {
        if(baseObj.gold >= 10)
        {
            bool upgrade = shootingObj.UpdateSpeed(0.02f);

            if (upgrade)
            {
                baseObj.gold -= 10;
            }
        }
    }

    public void AddArrow()
    {
        if (baseObj.gold >= 10)
        {
            bool upgrade = shootingObj.UpdateArrowCount();

            if (upgrade)
            {
                baseObj.gold -= 10;
            }
        }
    }

    public void SpawnAlly()
    {
        if (baseObj.gold >= 10)
        {
            bool upgrade = spawner.UpdateAllies();

            if (upgrade)
            {
                baseObj.gold -= 10;
            }
        }
    }

    public void SpawnShooter()
    {
        if (baseObj.gold >= 10)
        {
            bool upgrade = spawnerShooters.UpdateAllies();

            if (upgrade)
            {
                baseObj.gold -= 10;
            }
        }
    }

    public void SpawnBarrage()
    {
        if (baseObj.gold >= 10)
        {
            baseObj.gold -= 10;
            spawnerBarrage.CallAttack();
        }
    }

    public void SpawnPhalanx()
    {
        if (baseObj.gold >= 10)
        {
            baseObj.gold -= 10;
            spawnerPhalanx.Spawn();
        }
    }
}
