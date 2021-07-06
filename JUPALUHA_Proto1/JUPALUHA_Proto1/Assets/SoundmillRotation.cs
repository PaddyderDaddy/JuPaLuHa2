using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundmillRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    public float RotationZ;
    public Rigidbody2D connectetrb;

    public bool isSoundtouching = false;

    public SoundmillRotation ConnectedSoundmill;
    public SoundmillRotation ConnectedScript;

    public float Timer;

    public delegate void RotationChange();
    public RotationChange onRotationChange;

    public Instruments InstrumentsScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ConnectedSoundmill.onRotationChange += Coolfunction;

        ConnectedScript.GetComponent<SoundmillRotation>();
    }

    void Update()
    {
        if (isSoundtouching)
            Timer += Time.deltaTime;

        if (Timer > 2f && isSoundtouching)
        {
            isSoundtouching = false;
            ConnectedScript.isSoundtouching = false;
 
            Timer = 0;
        }

        //setting maxima for rotation velocity
        float newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -180, 180);

        if(isSoundtouching==true)
            newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -240, 240);

        rb.angularVelocity = newAngularVelocity;

        if (onRotationChange != null)
        {
            if (Mathf.Round(newAngularVelocity) != 0 && GameManager.instance.ActiveSoundmill == this)
                onRotationChange();
        }
    }

    void Coolfunction()
    {
        rb.angularVelocity = connectetrb.angularVelocity;
    }

    //Sobald der Sound die Soundmills aktiviert soll der Player nicht mehr sein Momentum benutzen um die SOundmills zu ver�ndern.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SoundPrefab")
        {
            isSoundtouching = true;
            ConnectedScript.isSoundtouching = true;
            Destroy(collision.gameObject);
            Timer = 0;
            ConnectedScript.Timer = Timer; // copying Timer value to connected soundmill's Timer

        }
    }

}
