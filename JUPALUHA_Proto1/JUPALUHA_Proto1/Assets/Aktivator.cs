 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aktivator : MonoBehaviour
{
    public bool AktivatorAktiv;
    public SoundmillRotation SoundmillScript;

    public CharControllerPhysics PlayerScript;
    //public Drumzone Drumzonescript;

    //private void Update()
    //{
    //    //if(SoundmillScript.isSoundtouching==false)
    //    //    AktivatorAktiv = false;

    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //AktivatorAktiv = true;

        if (PlayerScript.DidawesomeJump == true)
            AktivatorAktiv = true;

        //if (PlayerScript.ChaRigidbody.velocity.y <= -40)
        //{
        //    AktivatorAktiv = true;
        //}
    }
}
