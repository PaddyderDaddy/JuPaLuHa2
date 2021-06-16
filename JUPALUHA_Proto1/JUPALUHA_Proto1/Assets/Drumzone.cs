using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drumzone : MonoBehaviour
{
    public GameObject vent;
    public bool isOpen;
    public bool ventOpen = true;

    [Header("Scripts")]
    public CharControllerPhysics PlayerScript;
    public DeploySound DeployScript;

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
        if (PlayerScript.ChaRigidbody.velocity.y <= -40 && ventOpen == false)
        {
            isOpen = true;
            vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 1, 0);
            Debug.Log("Jump1");
        }

        if (PlayerScript.ChaRigidbody.velocity.y <= -40 && ventOpen == true)
        {
            vent.transform.localPosition = new Vector3(vent.transform.localPosition.x, 0, 0);
            isOpen = false;
            Debug.Log("Jump2");
        }
    }

}
