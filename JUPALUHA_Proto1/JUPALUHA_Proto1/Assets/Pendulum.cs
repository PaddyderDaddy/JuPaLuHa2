using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb;
    bool movingClockwise;
    float maxSpeed;

    [SerializeField] GameObject pipe;

    CharControllerPhysics characterScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = 100;

        characterScript = FindObjectOfType<CharControllerPhysics>();
    }

    private void Update()
    {
        if (characterScript.isOnPendulum)
            PendulumRotation();

        if (Mathf.Round(rb.angularVelocity) == 0 && characterScript.isOnPendulum)
        {
            if (movingClockwise)
                rb.angularVelocity = -maxSpeed;
            else
                rb.angularVelocity = maxSpeed;
        }

        if (!characterScript.isOnPendulum)
            rb.angularVelocity = 0;
    }

    void PendulumRotation()
    {
        //decelerate pendulum
        if (!movingClockwise && transform.eulerAngles.z >= 22.5f && transform.eulerAngles.z <= 55f) //right hemisphere
            rb.angularVelocity *= 0.985f;
        else if (movingClockwise && transform.eulerAngles.z <= 337.5f && transform.eulerAngles.z >= 305f) //left hemisphere
            rb.angularVelocity *= 0.985f;

        //accelerate pendulum
        if (movingClockwise && transform.eulerAngles.z >= 22.5f && transform.eulerAngles.z <= 55f) //right hemisphere
            rb.angularVelocity *= 1.015f;
        else if (!movingClockwise && transform.eulerAngles.z <= 337.5f && transform.eulerAngles.z >= 305f) //left hemisphere
            rb.angularVelocity *= 1.015f;

        //reversing velocity on angular point
        if (Mathf.Round(transform.eulerAngles.z) == 55 && !movingClockwise)
        {
            rb.angularVelocity = -maxSpeed;
            movingClockwise = true;
        }
        else if (Mathf.Round(transform.eulerAngles.z) == 305 && movingClockwise)
        {
            rb.angularVelocity = maxSpeed;
            movingClockwise = false;
        }

        //setting pipe angles to pendulum angles
        pipe.transform.localEulerAngles = transform.eulerAngles;

        //setting maximum velocity for pendulum
        if (rb.angularVelocity >= maxSpeed && !movingClockwise)
            rb.angularVelocity = maxSpeed;
        else if (rb.angularVelocity <= -maxSpeed && movingClockwise)
            rb.angularVelocity = -maxSpeed;

        //setting maximum angles for pendulum
        if (transform.eulerAngles.z >= 55 && transform.eulerAngles.z <= 180)
            transform.eulerAngles = new Vector3(0, 0, 55);
        else if (transform.eulerAngles.z <= 305 && transform.eulerAngles.z >= 180)
            transform.eulerAngles = new Vector3(0, 0, 305);
    }
}
