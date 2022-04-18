using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    public float arrowForce = 10f;
    public bool delay = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&(!delay))
        {
            StartCoroutine(Fire());
            //Shoot();
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.transform.Rotate(0, 0, 90);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
    }

    IEnumerator Fire()
    {
        delay = true;
        Shoot();
        yield return new WaitForSeconds(0.2f);
        delay = false;
    }
}
