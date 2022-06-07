using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phalanx : MonoBehaviour
{
    public Rigidbody2D rb;
    public float dirY;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        dirY = 2f;
        moveSpeed = 2f;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, dirY * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("border"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
