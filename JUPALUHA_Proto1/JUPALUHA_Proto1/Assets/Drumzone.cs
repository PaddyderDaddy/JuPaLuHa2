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

    public GameObject PowerjumpAUDIO;


    private void Start()
    {
        closedVent = vent.transform.localEulerAngles;
        openVent = closedVent + new Vector3(0, 0, 120);
        PowerjumpAUDIO.gameObject.SetActive(false);
    }

    private void Update()
    {
        //if (instrumentscript.connectetInstruaktiv == true || instruAscript.connectetInstruaktivA == true)
        //    Debug.Log("eulerAngles: " + vent.transform.localEulerAngles.z);

        if (vent.transform.localEulerAngles.z == openVent.z)
        {
            //Debug.Log("if this, that would be weird");
           // Debug.Log("vent open");
            ventOpen = true;
        }
        else if (vent.transform.localEulerAngles.z == closedVent.z)
        {
            //Debug.Log("and then this, apparently");
           // Debug.Log("vent closed");
            ventOpen = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touching");

        if (instrumentscript.connectetInstruaktiv == true || instruAscript.connectetInstruaktivA == true)
        {
            if (PlayerScript.ChaRigidbody.velocity.y <= -40 && ventOpen == false)
            {
             
                isOpen = true;
                Instantiate(PowerjumpAUDIO, new Vector2(0,0), Quaternion.Euler(0, 0, 0));
                PowerjumpAUDIO.gameObject.SetActive(true);

                vent.transform.localEulerAngles = openVent;
            }
        
        }
    }

  
}
