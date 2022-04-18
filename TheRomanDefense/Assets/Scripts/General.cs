using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;
    public bool shoot;

    Vector2 mousePos;

    private void Start()
    {
        shoot = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            shoot = true;
            anim.SetBool("shoot", shoot);
        }

        if (Input.GetMouseButtonUp(0))
        {
            shoot = false;
            anim.SetBool("shoot", shoot);
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
    }
}
