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

    [SerializeField] Vector3 closedVent;
    [SerializeField] Vector3 openVent;

    private void Start()
    {
        closedVent = vent.transform.localEulerAngles;
        openVent = closedVent + new Vector3(0, 0, 180);
    }

    private void FixedUpdate()
    {
        if (instrumentscript.connectetInstruaktiv == true || instruAscript.connectetInstruaktivA == true)
            Debug.Log("eulerAngles: " + vent.transform.localEulerAngles.z);

        if (vent.transform.localEulerAngles.z == openVent.z)
        {
            Debug.Log("vent open");
            ventOpen = true;
        }
        else if (vent.transform.localEulerAngles.z == closedVent.z)
        {
            Debug.Log("vent closed");
            ventOpen = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (instrumentscript.connectetInstruaktiv == true || instruAscript.connectetInstruaktivA == true)
        {
            if (PlayerScript.ChaRigidbody.velocity.y <= -40 && ventOpen == false)
            {
                Debug.Log("opening vent");
                isOpen = true;
                //vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 1, 0);
                vent.transform.localEulerAngles = openVent;
            }
            if (PlayerScript.ChaRigidbody.velocity.y <= -40 && ventOpen == true)
            {
                Debug.Log("closing vent");
                isOpen = false;
                //vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 0, 0);
                vent.transform.localEulerAngles = closedVent;
            }
        }
    }
}
