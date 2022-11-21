using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarAllyHealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 100f;
    WarAllyBase baseObj;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        baseObj = FindObjectOfType<WarAllyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = baseObj.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
