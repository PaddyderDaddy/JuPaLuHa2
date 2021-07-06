using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRaycast : MonoBehaviour
{
    Vector2 origin;
    Vector2 direction;

    RaycastHit2D hit;
    [SerializeField] float rayDist;

    bool soundOutput = false;
    bool clockwise = true;

    private void Start()
    {
        origin = transform.position;
    }

    private void Update()
    {
        origin = transform.position;

        float angle = gameObject.transform.eulerAngles.z;

        direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
        Debug.DrawLine(origin, origin + (direction * rayDist), Color.red);
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(origin, origin + direction, rayDist);

        //if (hit.collider.gameObject.CompareTag("positive") && soundOutput == true)
        //    clockwise = false; //rb.angularVelocity = value;

        //Debug.DrawLine(origin, origin + (direction * rayDist), Color.red);
    }

    //bool ClockwiseHit()
    //{
    //    bool val = false;

    //    hit = Physics2D.Raycast(origin, origin + direction, rayDist);

    //    if (hit.collider != null)
    //    {
    //        if (hit.collider.gameObject.CompareTag("positive") && soundOutput == true)
    //        {
    //            val = false;
    //        }
    //        else if (hit.collider.gameObject.CompareTag("negative") && soundOutput == true)
    //        {
    //            val = true;
    //        }
    //    }

    //    return val;
    //}
}
