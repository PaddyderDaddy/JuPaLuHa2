using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundmillRotation : MonoBehaviour
{
    //transform
    /*
    public Transform SoundmillParent;
    public Transform Pin1;
    public Transform Pin2;
    public Transform Pin3;
    public Transform Pin4;
    public Transform Pin5;
    */

    public Rigidbody2D rb;
    public float RotationZ;
    GameObject connectetSoundmill;
    public Rigidbody2D connectetrb;
    
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
       // connectetrb = GetComponent<Rigidbody2D>();
        //GameObject thePlayer = GameObject.Find("Player");
      //  playerScript = thePlayer.GetComponent<CharControllerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        //RotationZ = transform.rotation.z;        
        if (rb.angularVelocity < 0f)
            rb.angularVelocity += 0.1f*Time.deltaTime; //Wenn die kleiner ist als 0.01 dann wird das unschön hin und her ditschen (o.001zb)
        if (rb.angularVelocity > 0)
            rb.angularVelocity -= 0.1f * Time.deltaTime;

        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -180, 180);
        connectetrb.angularVelocity = rb.angularVelocity;         //rb.angularVelocity = connectetrb.angularVelocity;
    
        /*      
        //transform.Rotate(0, 0, RotationZ); FindObjectOfType<Interaction>().ItemMove();
        isonsoundmill = playerScript.PlayerattachedtoSoundmill; 
        if (isonsoundmill==true)
        {
            //Debug.Log("is true");
            playervel = playerScript.PlayerVelocity;

            //rb.angularVelocity.magnitude

             //transform.rotation.SetLookRotation(playervel);
        }
        //Debug.Log(playerScript.PlayerVelocity);    
        //velocity Rotation nachschauen
        //Angular Velocity     

        /*if(PlayerattechedtoSoundmill = true)
         * Playermomentum();
         * Rotation Lerp ! damit es langsam läuft...
         * Playerwasthere = true      
         * 
        if(Playerwasthere = true)
           Soundmillrotation --;

        if(Playerwasthere ==true && Soundmillrotation < 0)
            Soundmillrotation = 0;


        // PinMovement = Pin
        //transform1.transform.position;
        // Pin.transform.localPosition = PinMovement;
        //Pintransform.position = ;
        */
    }
}
