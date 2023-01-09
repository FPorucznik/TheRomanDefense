using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarEnemyHealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 100f;
    WarEnemyBase baseObj;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        baseObj = FindObjectOfType<WarEnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        //fill healthbar depending on current health value
        currentHealth = baseObj.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
