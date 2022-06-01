using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Base baseObj;
    private Shooting shootingObj;

    // Start is called before the first frame update
    void Start()
    {
        baseObj = FindObjectOfType<Base>();
        shootingObj = FindObjectOfType<Shooting>();
    }

    public void FixWall()
    {
        if(baseObj.gold >= 10)
        {
            baseObj.health = 100;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
