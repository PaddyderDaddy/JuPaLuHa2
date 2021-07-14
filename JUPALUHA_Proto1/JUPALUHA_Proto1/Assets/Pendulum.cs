using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rbPendulum;
    bool movingClockwise = false;
    float maxSpeed;

    [SerializeField] GameObject pipe;

    CharControllerPhysics characterScript;

    private void Start()
    {
        rbPendulum = gameObject.GetComponent<Rigidbody2D>();
        maxSpeed = 100;

        characterScript = FindObjectOfType<CharControllerPhysics>();
    }

    private void Update()
    {
        if (GameManager.instance.ActivePendulum != null)
        {
            if (characterScript.isOnPendulum && GameManager.instance.ActivePendulum == this)
            {
                if (Mathf.Round(rbPendulum.angularVelocity) == 0 && characterScript.isOnPendulum)
                {
                    if (movingClockwise)
                        rbPendulum.angularVelocity = -maxSpeed;
                    else
                        rbPendulum.angularVelocity = maxSpeed;
                }

                PendulumRotation();
            }
            else
                rbPendulum.angularVelocity = 0;
        }
    }

    void PendulumRotation()
    {
       // Debug.Log("is on pendulum");
        //decelerate pendulum
        if (!movingClockwise && transform.eulerAngles.z >= 22.5f && transform.eulerAngles.z <= 55f) //right hemisphere
            rbPendulum.angularVelocity *= 0.985f;
        else if (movingClockwise && transform.eulerAngles.z <= 337.5f && transform.eulerAngles.z >= 305f) //left hemisphere
            rbPendulum.angularVelocity *= 0.985f;

        //accelerate pendulum
        if (movingClockwise && transform.eulerAngles.z >= 22.5f && transform.eulerAngles.z <= 55f) //right hemisphere
            rbPendulum.angularVelocity *= 1.015f;
        else if (!movingClockwise && transform.eulerAngles.z <= 337.5f && transform.eulerAngles.z >= 305f) //left hemisphere
            rbPendulum.angularVelocity *= 1.015f;

        //reversing velocity on angular point
        if (Mathf.Round(transform.eulerAngles.z) == 55 && !movingClockwise)
        {
            rbPendulum.angularVelocity = -maxSpeed;
            movingClockwise = true;
        }
        else if (Mathf.Round(transform.eulerAngles.z) == 305 && movingClockwise)
        {
            rbPendulum.angularVelocity = maxSpeed;
            movingClockwise = false;
        }

        //setting pipe angles to pendulum angles
        pipe.transform.localEulerAngles = transform.eulerAngles;

        //setting maximum velocity for pendulum
        if (rbPendulum.angularVelocity >= maxSpeed && !movingClockwise)
            rbPendulum.angularVelocity = maxSpeed;
        else if (rbPendulum.angularVelocity <= -maxSpeed && movingClockwise)
            rbPendulum.angularVelocity = -maxSpeed;

        //setting maximum angles for pendulum
        if (transform.eulerAngles.z >= 55 && transform.eulerAngles.z <= 180)
            transform.eulerAngles = new Vector3(0, 0, 55);
        else if (transform.eulerAngles.z <= 305 && transform.eulerAngles.z >= 180)
            transform.eulerAngles = new Vector3(0, 0, 305);
    }
}
