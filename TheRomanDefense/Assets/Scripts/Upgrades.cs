using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private Base baseObj;

    // Start is called before the first frame update
    void Start()
    {
        baseObj = FindObjectOfType<Base>();
    }

    public void FixWall()
    {
        if(baseObj.gold >= 10)
        {
            baseObj.health = 100;
            baseObj.gold -= 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
