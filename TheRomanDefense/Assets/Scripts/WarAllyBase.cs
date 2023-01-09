using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarAllyBase : MonoBehaviour
{
    public float health = 100f;
    public int gold = 100;
    public Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        //run a a repeating method every 10 seconds for passive gold income
        InvokeRepeating("PassiveIncome", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        //update gold amount on screen and check if base still has health, if not then game over
        goldText.text = gold.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void PassiveIncome()
    {
        gold += 20;
    }
}
