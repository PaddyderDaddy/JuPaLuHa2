using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundmillRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    public float RotationZ;
    GameObject connectetSoundmill;
    public Rigidbody2D connectetrb;

    public SoundmillRotation ConnectedSoundmill;


    public delegate void RotationChange();
    public RotationChange onRotationChange;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ConnectedSoundmill.onRotationChange += Coolfunction;
    }
    void Update()
    {
        if (rb.angularVelocity < 0f)
            rb.angularVelocity += 10f * Time.deltaTime; //Wenn die kleiner ist als 0.01 dann wird das unschön hin und her ditschen (o.001zb)
        if (rb.angularVelocity > 0)
            rb.angularVelocity -= 10f * Time.deltaTime;

        //setting maxima for rotation velocity
        float newAngularVelocity = Mathf.Clamp(rb.angularVelocity, -180, 180);

        rb.angularVelocity = newAngularVelocity;

        if (onRotationChange != null)
        {
            if (Mathf.Round(newAngularVelocity) != 0 && GameManager.instance.ActiveSoundmill == this)
                onRotationChange();
        }
    }
    void Coolfunction()
    {
        Debug.Log("this works");
        rb.angularVelocity = connectetrb.angularVelocity;
    }
}
