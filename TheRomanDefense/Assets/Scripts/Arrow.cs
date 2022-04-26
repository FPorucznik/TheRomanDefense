using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
     
    }

}
