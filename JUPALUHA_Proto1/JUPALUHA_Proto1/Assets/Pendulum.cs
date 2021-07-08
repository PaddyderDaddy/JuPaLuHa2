using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] GameObject pipe;
    [SerializeField] float rotZ;

    bool movingClockwise;

    CharControllerPhysics characterScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //rb.angularVelocity = 30;
        //movingClockwise = false;

        characterScript = FindObjectOfType<CharControllerPhysics>();
    }

    private void Update()
    {
        if (characterScript.isOnPendulum)
            PendulumRotation();

        if (Mathf.Round(rb.angularVelocity) == 0 && characterScript.isOnPendulum)
        {
            rb.angularVelocity = 30;
            movingClockwise = false;
        }

        if (!characterScript.isOnPendulum)
            rb.angularVelocity = 0;
    }

    void PendulumRotation()
    {
        //Debug.Log("Rotation: " + Mathf.Round(rb.angularVelocity));

        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 180 && !movingClockwise)
            rb.angularVelocity *= 0.99f;
        else if (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= 180 && movingClockwise)
            rb.angularVelocity *= 0.99f;

        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 180 && movingClockwise)
            rb.angularVelocity *= 1.01f;
        else if (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= 180 && !movingClockwise)
            rb.angularVelocity *= 1.01f;


        if (Mathf.Round(rb.angularVelocity) == 5 && !movingClockwise)
        {
            rb.angularVelocity = -10;
            movingClockwise = true;
        }
        else if (Mathf.Round(rb.angularVelocity) == -5 && movingClockwise)
        {
            rb.angularVelocity = 10;
            movingClockwise = false;
        }

        if (Mathf.Round(transform.eulerAngles.z) >= 0 && Mathf.Round(transform.eulerAngles.z) <= 1 && !movingClockwise)
            pipe.transform.localEulerAngles = new Vector3(0, 0, rotZ);
        else if (Mathf.Round(transform.eulerAngles.z) <= 360 && Mathf.Round(transform.eulerAngles.z) >= 359 && movingClockwise)
            pipe.transform.localEulerAngles = new Vector3(0, 0, -rotZ);

        if (rb.angularVelocity >= 50 && !movingClockwise)
            rb.angularVelocity = 50;
        else if (rb.angularVelocity <= -50 && movingClockwise)
            rb.angularVelocity = -50;
    }
}
