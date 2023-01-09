using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHeavySoldier : MonoBehaviour
{
    public Rigidbody2D rb;
    public float dirX;
    public float moveSpeed;
    public bool attack;
    public Animator anim;
    WarEnemyBase baseObj;
    public float health;
    private bool stand;

    // Start is called before the first frame update
    private void Start()
    {
        dirX = 1f;
        moveSpeed = 1f;
        attack = false;
        anim = GetComponent<Animator>();
        baseObj = FindObjectOfType<WarEnemyBase>();
        health = 3f;
        stand = false;
    }

    private void FixedUpdate()
    {
        //apply movement velocity to soldier object
        if (!stand)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //detect collisions with objects with specific tags and handle attacking/movement
        if (collision.collider.CompareTag("enemy"))
        {
            attack = true;
            anim.SetBool("attack", attack);
            InvokeRepeating("DamageBase", 0f, 1f);
        }

        if (collision.collider.CompareTag("warAlly"))
        {
            if (!attack)
            {
                stand = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("stand", stand);
            }
        }

        if (collision.collider.CompareTag("warEnemy"))
        {
            attack = true;
            anim.SetBool("attack", attack);
            InvokeRepeating("DamageEnemy", 0f, 1f);
        }

        if (collision.collider.CompareTag("enemyFortification"))
        {
            attack = true;
            anim.SetBool("attack", attack);
            GameObject obj = collision.collider.gameObject;
            Fortification fortification = obj.GetComponent<Fortification>();
            fortification.Collide();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //detect moment when object exits a collision with objects with specific tags and handle attacking/movement
        if (collision.collider.CompareTag("warEnemy"))
        {
            attack = false;
            anim.SetBool("attack", attack);
            CancelInvoke();
        }

        if (collision.collider.CompareTag("warAlly"))
        {
            if (!attack)
            {
                stand = false;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                anim.SetBool("stand", stand);
            }
        }

        if (collision.collider.CompareTag("enemyFortification"))
        {
            attack = false;
            anim.SetBool("attack", attack);
            CancelInvoke();
        }
    }

    //runs every frame
    private void Update()
    {
        //checking objects health
        if (health <= 0)
        {
            baseObj.gold += 20;
            Destroy(gameObject);
        }
    }

    //runs when a collision with target base is detected
    private void DamageBase()
    {
        baseObj.health -= 1f;
    }

    //runs when a collision with opposing unit is detected
    private void DamageEnemy()
    {
        health -= 0.2f;
    }
}
