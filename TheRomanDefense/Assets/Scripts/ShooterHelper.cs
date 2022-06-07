using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHelper : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool attack;
    public Animator anim;
    ShooterHelperSpawner spawner;
    public int point;
    Barbarian enemyObj;
    Vector2 enemyPos;
    public bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
        anim = GetComponent<Animator>();
        enemyObj = FindObjectOfType<Barbarian>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyObj)
        {
            enemyObj = FindObjectOfType<Barbarian>();
        }
    }

    private void FixedUpdate()
    {
        if (enemyObj)
        {
            enemyPos = enemyObj.transform.position;
            shoot = true;
            anim.SetBool("shoot", shoot);
        }
        else
        {
            shoot = false;
            anim.SetBool("shoot", shoot);
        }
        Vector2 lookDir = enemyPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
