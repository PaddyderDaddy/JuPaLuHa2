using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundmillRotation : MonoBehaviour
{
    public enum InteractionType { A, B }
    public InteractionType type;

    public Rigidbody2D rb;
    //public float RotationZ;
    public Rigidbody2D connectetrb;

    public bool isSoundtouching = false;

    public SoundmillRotation ConnectedSoundmill;
    public SoundmillRotation ConnectedScript;

    // public float Timer;

    public delegate void RotationChange();
    public RotationChange onRotationChange;

    public Instruments InstrumentsScript;

    public CheckAngle checkanglescript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ConnectedSoundmill.onRotationChange += Coolfunction;

        ConnectedScript.GetComponent<SoundmillRotation>();
    }

    void Update()
    {
        Soundmillandvent();

        //setting maxima for rotation velocity

        float newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -180, 180);

        if(isSoundtouching==true)
        {          
            newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -240, 240);
            //sobald der vent auf den connecteten soundmill ist wird hier die ang velocity übertragen: problem danach nicht mehr weg, muss danach wieder für player nutzbar sein
        }

       
        
        rb.angularVelocity = newAngularVelocity;

        if (onRotationChange != null)
        {
            if (Mathf.Round(newAngularVelocity) != 0 && GameManager.instance.ActiveSoundmill == this)
                onRotationChange();
        }

        //noch macht der gar nichts bzw er soll seine ANg Vel auf seine Connectet rb übertragen. Morgen mit Julian!
        if (isSoundtouching == true)
        {

        }
        if (isSoundtouching == false)
            rb.angularVelocity = connectetrb.angularVelocity;

    }

    void Coolfunction()
    {
        rb.angularVelocity = connectetrb.angularVelocity;
    }

    void Soundmillandvent()
    {
        switch (type)
        {

            case InteractionType.A:

                if (checkanglescript != null) //kein komischer spam 
                {
                    if (checkanglescript.Raycastsoundhit1 == true)
                    {
                        isSoundtouching = true;
                        ConnectedScript.isSoundtouching = true;
                    }
                    else
                    {
                        isSoundtouching = false;
                        ConnectedScript.isSoundtouching = false;
                    }
                }

                break;

            case InteractionType.B:

                if (checkanglescript != null) //kein komischer spam 
                {
                    if (checkanglescript.Raycastsoundhit2 == true)
                    {
                        isSoundtouching = true;
                        ConnectedScript.isSoundtouching = true;
                    }
                    else
                    {
                        isSoundtouching = false;
                        ConnectedScript.isSoundtouching = false;
                    }
                }

                break;

        }
    }
}
