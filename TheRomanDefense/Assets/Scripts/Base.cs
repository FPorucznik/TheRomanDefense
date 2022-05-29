using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float health = 100f;
    public int gold = 0;
    public Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = gold.ToString();
        if(health == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
