using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fortification : MonoBehaviour
{
    public Rigidbody2D rb;
    public float health;
    private WarAllySpawner spawner;
    private WarEnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        health = 4f;
        spawner = FindObjectOfType<WarAllySpawner>();
        enemySpawner = FindObjectOfType<WarEnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Fortification fortification = gameObject.GetComponent<Fortification>();
            if(fortification.tag == "allyFortification")
            {
                Destroy(gameObject);
                spawner.spawnDefenseBtn.interactable = true;
            }
            else
            {
                Destroy(gameObject);
                enemySpawner.isFortification = false;
            }
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
