using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMenu : MonoBehaviour
{
    public Transform soundmillUI;
    public Rigidbody2D rb;
    // Update is called once per frame

    public GameObject StartSpitze;
    public GameObject OptionSpitze;
    public GameObject QuitSpitze;

    public float Rotationamount;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.angularVelocity = 20;

    }
    void Update()
    {
        //if (rb.angularVelocity < 0f)
        //    rb.angularVelocity += 10f * Time.deltaTime; //Wenn die kleiner ist als 0.01 dann wird das unschön hin und her ditschen (o.001zb)
        // if (rb.angularVelocity > 0)
        //     rb.angularVelocity -= 10f * Time.deltaTime;
        //soundmillUI.transform.Rotate(0f,0f,0.05f,Space.Self);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rb.angularVelocity = -Rotationamount;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rb.angularVelocity = Rotationamount;
    }
}

//Player.transform.parent = null;
//PLPO.transform.parent = null; //Nicht mehr Child des Hooks
//HookGrab.transform.parent = null; //nicht mehr Child des Players
//                                  //PARENTEN
//HookGrab.transform.parent = Player.transform; //Hook = Child des Player
//PLPO.transform.parent = HookGrab.transform;   //PLPO = Child des Hooks   
//HookGrab.transform.localPosition = new Vector3(-0.6f, 0.8f, 0); //-0.7f
//PLPO.transform.localPosition = new Vector3(0, 0, 0); //0.4f  (0.3f, 1.5f, 0)