 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aktivator : MonoBehaviour
{
    public bool AktivatorAktiv;
    public SoundmillRotation SoundmillScript;

    public CharControllerPhysics PlayerScript;
    public GameObject PowerjumpAUDIO;

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
        {
            AktivatorAktiv = true;
            Instantiate(PowerjumpAUDIO, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));

        }

        //if (PlayerScript.ChaRigidbody.velocity.y <= -40)
        //{
        //    AktivatorAktiv = true;
        //}
    }
}
