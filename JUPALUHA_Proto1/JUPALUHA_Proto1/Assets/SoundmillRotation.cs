using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundmillRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D connectetrb;

    public bool isSoundtouching = false;

    public SoundmillRotation ConnectedSoundmill;
    public SoundmillRotation ConnectedScript;

    public delegate void RotationChange();
    public RotationChange onRotationChange;

    //public Instruments InstrumentsScript;

    //public CheckAngle checkanglescript;

    public bool isSoundmillFuckingActive = false;
    public bool isPoweredByRaycast = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ConnectedSoundmill.onRotationChange += Coolfunction;

        ConnectedScript.GetComponent<SoundmillRotation>();
    }

    void Update()
    {
        //setting maxima for rotation velocity
        float newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -180, 180);

        if(isSoundtouching==true)
        {          
            newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -240, 240);
        }    
        
        rb.angularVelocity = newAngularVelocity;

        if (onRotationChange != null)
        {
            if (Mathf.Round(newAngularVelocity) != 0 && isSoundmillFuckingActive)
                onRotationChange();
        }
    }

    void Coolfunction()
    {
        rb.angularVelocity = connectetrb.angularVelocity;
    }
}
