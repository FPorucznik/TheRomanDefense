using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fortification : MonoBehaviour
{
    public Rigidbody2D rb;
    public float health;
    private WarAllySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        health = 6f;
        spawner = FindObjectOfType<WarAllySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            spawner.spawnDefenseBtn.interactable = true;
        }
    }

    public void Collide()
    {
        InvokeRepeating("TakeDamage", 0f, 1f);
    }

    private void TakeDamage()
    {
        health -= 0.2f;
    }

}
