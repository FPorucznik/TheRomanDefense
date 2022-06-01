using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    public float arrowForce = 10f;
    public bool delay = false;

    private float speed = 0.3f;

    private int arrowCount = 1;
    private List<GameObject> arrows = new List<GameObject>();
    private List<int> rotations = new List<int>();
    private Vector3 rot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&(!delay))
        {
            StartCoroutine(Fire());
            //Shoot();
        }
        
        if(arrowCount == 1)
        {
            // Vector3 rot = firePoint.rotation.eulerAngles;
            rot = firePoint.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z);
            firePoint.rotation = Quaternion.Euler(rot);

            rotations.Clear();
            rotations.Add(-80);
            //rotations.Add(-250);
        }
        else if(arrowCount == 2)
        {
            rotations.Clear();
            rotations.Add(-80);
            rotations.Add(-100);
        }
    }

    void Shoot()
    {
        //rot = new Vector3(rot.x, rot.y, rot.z-10);
        //firePoint.rotation = Quaternion.Euler(rot);
        for (int i=0; i<arrowCount; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            arrows.Add(arrow);
        }

        for(int i=0; i<arrowCount; i++)
        {
            arrows[i].transform.Rotate(0, 0, 90);
            Rigidbody2D rb = arrows[i].GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        }
        arrows.Clear();
        //GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        //arrow.transform.Rotate(0, 0, 90);
        //Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
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
        if(arrowCount < 4)
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
