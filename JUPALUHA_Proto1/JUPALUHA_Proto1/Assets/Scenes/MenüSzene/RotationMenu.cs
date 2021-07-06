using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMenu : MonoBehaviour
{
    public Transform soundmillUI;
    public Rigidbody2D rb;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 20;

    }
    void Update()
    {
        //if (rb.angularVelocity < 0f)
        //    rb.angularVelocity += 10f * Time.deltaTime; //Wenn die kleiner ist als 0.01 dann wird das unschön hin und her ditschen (o.001zb)
       // if (rb.angularVelocity > 0)
       //     rb.angularVelocity -= 10f * Time.deltaTime;
        //soundmillUI.transform.Rotate(0f,0f,0.05f,Space.Self);
    }
}
