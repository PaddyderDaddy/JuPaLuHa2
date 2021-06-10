using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drumzone : MonoBehaviour
{
    public CharControllerPhysics PlayerScript;
    public DeploySound DeployScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(PlayerScript.ChaRigidbody.velocity);
        if (PlayerScript.ChaRigidbody.velocity.y <= -40 && DeployScript.ventOpen == false)
            FindObjectOfType<Vent>().MoveVent();

        if (PlayerScript.ChaRigidbody.velocity.y <= -40 && DeployScript.ventOpen == true)
            FindObjectOfType<Vent>().CloseVent();
    }
   
}
