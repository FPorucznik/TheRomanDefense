﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 100f;
    Base baseObj;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        baseObj = FindObjectOfType<Base>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = baseObj.health;
        healthBar.fillAmount = currentHealth / maxHealth;
        //SceneManager.LoadScene(0);
    }
}
