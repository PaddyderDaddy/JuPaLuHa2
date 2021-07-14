using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationMenu : MonoBehaviour
{
    public Transform soundmillUI;
    public Rigidbody2D rb;
    // Update is called once per frame

    public GameObject Trigger;
    public GameObject RotationAudio;
    public enum Soundmills { left, right }
    public Soundmills type;
    public float newrotation;

    bool PlayedSound = false;

    public float Rotationamount;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.angularVelocity = 20;
        if(RotationAudio !=null)
             RotationAudio.gameObject.SetActive(false);

    }
    void Update()
    {
        //if (rb.angularVelocity < 0f)
        //    rb.angularVelocity += 10f * Time.deltaTime; //Wenn die kleiner ist als 0.01 dann wird das unschön hin und her ditschen (o.001zb)
        // if (rb.angularVelocity > 0)
        //     rb.angularVelocity -= 10f * Time.deltaTime;
        //soundmillUI.transform.Rotate(0f,0f,0.05f,Space.Self);
        switch (type)
        {
            case Soundmills.left:

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    rb.angularVelocity = -Rotationamount;

                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.angularVelocity = Rotationamount;

                }


                break;
            case Soundmills.right:

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    rb.angularVelocity = Rotationamount;

                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.angularVelocity = -Rotationamount;

                }

                break;
            default:
                Debug.Log("NONE");
                break;


        }
        if (RotationAudio != null)
        {

            if (PlayedSound == false)
            {
                PlayedSound = true;
                //Instantiate(RotationAudio, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
                RotationAudio.gameObject.SetActive(true);
            }
            if (rb.angularVelocity == 0)
            {
                RotationAudio.gameObject.SetActive(false);
                PlayedSound = false;
            }
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Menutrigger")
        {
            StartCoroutine(Wait());
        }
        

        

    }

    IEnumerator Wait()
    {

        Rotationamount = 0;
        rb.angularDrag = 20;
        
        yield return new WaitForSeconds(0.4f);
        Rotationamount = newrotation;
        rb.angularDrag = 0.3f;
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