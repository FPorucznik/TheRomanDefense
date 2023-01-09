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
        //checking if fortification still has health, if not then destroy correct object depending on tag and allow purchase and enable button
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

    //runs when object collides with unit and invokes method to take damage
    public void Collide()
    {
        InvokeRepeating("TakeDamage", 0f, 1f);
    }

    //method that reduces objects health when attacked
    private void TakeDamage()
    {
        health -= 0.2f;
    }

}
