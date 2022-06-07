using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootersShooting : MonoBehaviour
{
    public Transform firePoint;
    public float arrowForce = 10f;
    public bool delay = false;
    private float speed = 0.4f;
    public GameObject arrowPrefab;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ShooterHelper>().shoot && (!delay))
        {
            StartCoroutine(Fire());
        }
        else
        {
            StopCoroutine(Fire());
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
        yield return new WaitForSeconds(speed);
        delay = false;
    }
}
