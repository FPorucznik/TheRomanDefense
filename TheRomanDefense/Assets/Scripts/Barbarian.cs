using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : MonoBehaviour
{
    public Rigidbody2D rb;
    public float dirX;
    public float moveSpeed;
    public bool attack;
    public Animator anim;
    Base baseObj;
    public float health;

    // Start is called before the first frame update
    private void Start()
    {
        dirX = -1f;
        moveSpeed = 1f;
        attack = false;
        anim = GetComponent<Animator>();
        baseObj = FindObjectOfType<Base>();
        health = 3f;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("base"))
        {
            attack = true;
            anim.SetBool("attack", attack);
            InvokeRepeating("DamageBase", 0f, 1f);
        }
        else if (collision.collider.CompareTag("ally"))
        {
            attack = true;
            anim.SetBool("attack", attack);
            InvokeRepeating("DamageAlly", 0f, 1f);
        }

        if (collision.collider.CompareTag("phalanx"))
        {
            baseObj.gold += 10;
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("arrow"))
        {
            health -= 1f;

            if(health <= 0f)
            {
                baseObj.gold += 10;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ally"))
        {
            attack = false;
            anim.SetBool("attack", attack);
            CancelInvoke();
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            baseObj.gold += 10;
            Destroy(gameObject);
        }
    }

    private void DamageBase()
    {
        baseObj.health -= 1f;
    }
    private void DamageAlly()
    {
        health -= 0.5f;
    }

}
