using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarEnemyBase : MonoBehaviour
{
    public float health = 100f;
    public int gold = 100;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PassiveIncome", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void PassiveIncome()
    {
        gold += 10;
    }
}
