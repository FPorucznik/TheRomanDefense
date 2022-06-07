using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : MonoBehaviour
{
    public Transform[] firePoints;
    public float arrowForce = 10f;
    public bool delay = false;
    public GameObject arrowPrefab;
    private int num = 0;

    // Update is called once per frame
    void Update()
    {

    }

    public void CallAttack()
    {
        num = 0;
        StartCoroutine(Fire());
    }

    public void Shoot()
    {
        //GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        //arrow.transform.Rotate(0, 0, 90);
        //Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
    }

    private IEnumerator Fire()
    {
        while(num < 9)
        {
            for (int i = 0; i < firePoints.Length; i++)
            {
                GameObject arrow = Instantiate(arrowPrefab, firePoints[i].position, firePoints[i].rotation);
                arrow.transform.Rotate(0, 0, 90);
                Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoints[i].up * arrowForce, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(0.15f);
            num++;
            if(num > 9)
            {
                StopCoroutine(Fire());
            }
        }
    }
}
