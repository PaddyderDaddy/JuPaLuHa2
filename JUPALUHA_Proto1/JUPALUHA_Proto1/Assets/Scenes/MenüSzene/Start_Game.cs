using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Game : MonoBehaviour
{
    RotationMenu rotationMenuScript;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Menutrigger")
            rotationMenuScript.Rotationamount = 0;
    }
}
