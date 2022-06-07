using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject arrowPrefab;

    public float arrowForce = 10f;
    public bool delay = false;

    private float speed = 0.3f;

    private int arrowCount = 1;
    private List<GameObject> arrows = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&(!delay))
        {
            StartCoroutine(Fire());
        }
        
    }

    void Shoot()
    {
        if(arrowCount == 1)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            arrows.Add(arrow);
            arrows[0].transform.Rotate(0, 0, 90);
            Rigidbody2D rb = arrows[0].GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        }
        else if(arrowCount == 2)
        {
            GameObject arrow2 = Instantiate(arrowPrefab, firePoint2.position, firePoint2.rotation);
            GameObject arrow3 = Instantiate(arrowPrefab, firePoint3.position, firePoint3.rotation);
            arrows.Add(arrow2);
            arrows.Add(arrow3);

            arrows[0].transform.Rotate(0, 0, 90);
            arrows[1].transform.Rotate(0, 0, 90);
            Rigidbody2D rb2 = arrows[0].GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = arrows[1].GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint2.up * arrowForce, ForceMode2D.Impulse);
            rb3.AddForce(firePoint3.up * arrowForce, ForceMode2D.Impulse);
        }
        else if (arrowCount == 3)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            GameObject arrow2 = Instantiate(arrowPrefab, firePoint2.position, firePoint2.rotation);
            GameObject arrow3 = Instantiate(arrowPrefab, firePoint3.position, firePoint3.rotation);
            arrows.Add(arrow);
            arrows.Add(arrow2);
            arrows.Add(arrow3);

            arrows[0].transform.Rotate(0, 0, 90);
            arrows[1].transform.Rotate(0, 0, 90);
            arrows[2].transform.Rotate(0, 0, 90);
            Rigidbody2D rb = arrows[0].GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = arrows[1].GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = arrows[2].GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
            rb2.AddForce(firePoint2.up * arrowForce, ForceMode2D.Impulse);
            rb3.AddForce(firePoint3.up * arrowForce, ForceMode2D.Impulse);
        }
        arrows.Clear();
    }

    IEnumerator Fire()
    {
        delay = true;
        Shoot();
        yield return new WaitForSeconds(speed);
        delay = false;
    }

    public bool UpdateSpeed(float val)
    {
        if(speed >= 0.1f)
        {
            speed -= val;
            return true;
        }
        else
        {
            Debug.Log("max speed");
            return false;
        }
    }

    public bool UpdateArrowCount()
    {
        if(arrowCount < 3)
        {
            arrowCount++;
            return true;
        }
        else
        {
            return false;
        }
    }
}
