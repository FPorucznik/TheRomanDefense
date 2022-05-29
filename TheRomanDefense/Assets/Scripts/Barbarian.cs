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
    public int health;

    // Start is called before the first frame update
    private void Start()
    {
        dirX = -1f;
        moveSpeed = 1f;
        attack = false;
        anim = GetComponent<Animator>();
        baseObj = FindObjectOfType<Base>();
        health = 3;
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

        if (collision.collider.CompareTag("arrow"))
        {
            //Debug.Log("i got hit");
            health--;

            if(health == 0)
            {
                baseObj.gold += 10;
                Destroy(gameObject);
            }
        }
    }

    private void DamageBase()
    {
        baseObj.health -= 1f;
    }

}
