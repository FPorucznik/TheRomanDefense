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

    // Start is called before the first frame update
    private void Start()
    {
        dirX = -1f;
        moveSpeed = 1f;
        attack = false;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "base")
        {
            Debug.Log("base attack");
            attack = true;
            anim.SetBool("attack", attack);
        }   
    }

}
