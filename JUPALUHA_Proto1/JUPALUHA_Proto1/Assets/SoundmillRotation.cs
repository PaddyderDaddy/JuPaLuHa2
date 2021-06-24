using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundmillRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    public float RotationZ;
    GameObject connectetSoundmill;
    public Rigidbody2D connectetrb;

    public bool isSoundtouching = false;

    public SoundmillRotation ConnectedSoundmill;
    public SoundmillRotation ConnectedScript;

    public float Timer;
    float time2 = 0;

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

        //if (rb.angularVelocity < 0f)
        //    rb.angularVelocity += 10f * Time.deltaTime; //Wenn die kleiner ist als 0.01 dann wird das unschön hin und her ditschen (o.001zb)
        //if (rb.angularVelocity > 0)
        //    rb.angularVelocity -= 10f * Time.deltaTime;

        //setting maxima for rotation velocity
        float newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -180, 180);

        rb.angularVelocity = newAngularVelocity;

        if (onRotationChange != null)
        {
            if (Mathf.Round(newAngularVelocity) != 0 && GameManager.instance.ActiveSoundmill == this)
                onRotationChange();
        }

        //if (Mathf.Round(newAngularVelocity) == 0)
        //    isSoundtouching = false;

        //if (InstrumentsScript.Instrumentactiv == true && isSoundtouching == true)
        //    rb.angularDrag = 1;
        //if (InstrumentsScript.Instrumentactiv == false && isSoundtouching == false)
        //    rb.angularDrag = 0.1f;


    }
    void Coolfunction()
    {
        //Debug.Log("this works");
        rb.angularVelocity = connectetrb.angularVelocity;
    }
    //Sobald der Sound die Soundmills aktiviert soll der Player nicht mehr sein Momentum benutzen um die SOundmills zu verändern.
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "VentTrigger")
    //    {
    //        //time2 += Time.deltaTime;

    //        isSoundtouching = true;
    //        ConnectedScript.isSoundtouching = true;
    //        //Destroy(collision.gameObject);
    //    }

    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SoundPrefab")
        {
            //time2 += Time.deltaTime;

            isSoundtouching = true;
            ConnectedScript.isSoundtouching = true;
            Destroy(collision.gameObject);
            Timer = 0;
            ConnectedScript.Timer = Timer; // copying Timer value to connected soundmill's Timer
        }
    }

}
