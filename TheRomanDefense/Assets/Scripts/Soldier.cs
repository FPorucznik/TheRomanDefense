using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool attack;
    public Animator anim;
    public float health;
    AllySpawner spawner;
    public int point;
    Barbarian enemyObj;

    // Start is called before the first frame update
    private void Start()
    {
        attack = false;
        anim = GetComponent<Animator>();
        spawner = FindObjectOfType<AllySpawner>();
        health = 5f;
    }

    private void Update()
    {
        if(health <= 0f)
        {
            Destroy(gameObject);
            spawner.UpdateAvailablePoints(point);
            spawner.current--;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            attack = true;
            anim.SetBool("attack", attack);
            InvokeRepeating("DamageEnemy", 0f, 1f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            attack = false;
            anim.SetBool("attack", attack);
            CancelInvoke();
        }
    }


    private void DamageEnemy()
    {
        health -= 0.2f;
    }
}
