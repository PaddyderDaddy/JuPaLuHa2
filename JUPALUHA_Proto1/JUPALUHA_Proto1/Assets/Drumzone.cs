using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drumzone : MonoBehaviour
{
    public GameObject vent;
    public bool isOpen = false; //Das ist das wichtige
    public bool ventOpen = false; 

    [Header("Scripts")]
    public CharControllerPhysics PlayerScript;
    public DeploySound DeployScript;

    public Instruments instrumentscript; //InstruAktiv
    public InstrumentAktivatorA instruAscript;
    public Rigidbody2D charRB;
    private void FixedUpdate()
    {
        if (vent.transform.localPosition.y >= 1)
        {
            ventOpen = true;
        }
        else
        {
            ventOpen = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //das lieber mal lassen, better safe than sorry
        //if (instrumentscript.connectetInstruaktiv == true || instruAscript.connectetInstruaktivA ==true)
        //{
        //    if (PlayerScript.DidawesomeJump == true && ventOpen == false)
        //    {
        //        Debug.Log("true");
        //        isOpen = true;
        //        vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 1, 0);
        //    }
        //    if (PlayerScript.DidawesomeJump == true && ventOpen == true)
        //    {
        //        Debug.Log("false");
        //        vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 0, 0);
        //        isOpen = false;
        //    }
        //}

        if (instrumentscript.connectetInstruaktiv == true || instruAscript.connectetInstruaktivA == true)
        {
            if (PlayerScript.ChaRigidbody.velocity.y <= -40 && ventOpen == false)
            {
                Debug.Log("true");
                isOpen = true;
                vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 1, 0);
            }
            if (PlayerScript.ChaRigidbody.velocity.y <= -40 && ventOpen == true)
            {
                Debug.Log("false");
                vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 0, 0);
                isOpen = false;
            }
        }
        // else
        // {
        //feedbackSound/vis das es noch nicht aufgeht
        // }     
    }
}
