using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEndingScript : MonoBehaviour
{
    public SoundmillRotation Soundmill1;
    public SoundmillRotation Soundmill2;
    public SoundmillRotation Soundmill3;
    public SoundmillRotation Soundmill4;

    public GameObject Player;
    public Transform PLPO;
    public Transform HookGrab;
    public Rigidbody2D ChaRigidbody;
    public CharControllerPhysics Charscript;
    public BoxCollider2D playercollider;

    public SoundmillRotation ownSoundmillRotscript;
    public GameObject DissonanceCloudsetc;
    public bool TheEndisnear = false;
    public bool Playeristhere = false;

    public PolygonCollider2D Instrument4;

    public CircleCollider2D Instrument3;

    void Start()
    {
        //Charscript = GetComponent<CharControllerPhysics>();
       // playercollider = GetComponent<BoxCollider2D>();
        ChaRigidbody = GetComponent<Rigidbody2D>();
       // Instrument4 = GetComponent<PolygonCollider2D>();
        //Instrument3 = GetComponent<CircleCollider2D>();

        // Soundmill1 = GetComponent<SoundmillRotation>();
        //Soundmill2 = GetComponent<SoundmillRotation>();
        //Soundmill3 = GetComponent<SoundmillRotation>();
        // Soundmill4 = GetComponent<SoundmillRotation>();

        //get the components of the player 
    }

    private void Update()
    {
        if (Soundmill1.isPoweredByRaycast == true && Soundmill2.isPoweredByRaycast == true && Soundmill3.isPoweredByRaycast == true && Soundmill4.isPoweredByRaycast == true)
            TheEndisnear = true;

        if(Playeristhere == true)
        {
            //press SPACE 
            //Physics.IgnoreLayerCollision(3, 7);
            //Physics.IgnoreLayerCollision(3, 10);       

            if (Input.GetKey(KeyCode.Space))
            {

                //VERSTOßEN
                Player.transform.parent = null;
                PLPO.transform.parent = null; //Nicht mehr Child des Hooks
                HookGrab.transform.parent = null; //nicht mehr Child des Players
                //PARENTEN
                HookGrab.transform.parent = Player.transform; //Hook = Child des Player
                PLPO.transform.parent = HookGrab.transform;   //PLPO = Child des Hooks   
                HookGrab.transform.localPosition = new Vector3(-0.7f, 0, 0);
                PLPO.transform.localPosition = new Vector3(0, 0.4f, 0);

                DissonanceCloudsetc.SetActive(false);
              
                ChaRigidbody.velocity = Vector2.down * 4 * 5;

                Shader.SetGlobalFloat("_AvaiblePowerjump", 6);
                Shader.SetGlobalFloat("_SpeedVelocity", 50);
               
            }
        }
    }
    public static void IgnoreLayerCollision(int layer1, int layer2, bool ignore = true)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" && TheEndisnear ==true)
        {
            Playeristhere = true;
            // ownSoundmillRotscript.enabled = !ownSoundmillRotscript.enabled;
            ChaRigidbody.velocity = new Vector3(0, 0, 0);
            ChaRigidbody.gravityScale = 0;
            Charscript.enabled = !Charscript.enabled;
            Instrument4.enabled = !Instrument4.enabled;
            Instrument3.enabled = !Instrument3.enabled;
        }
    }

        //every Soundmill connectet

        //CharControllerPhysics

        // Start is called before the first frame update
        /*

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag(Player) && IsEndingtrue ==true && )
            {
                deaktivate all the components of the player(Collider, physic controller)

                if(Keypressed(get.Keycode(Space)) || is Rotation.Z==fixerwertganz oben)
                {
                    Entparent des todes;
                    Ähnlich powerjump; (Alle shadereffekte)
                    sound;
                }
        }

        Das dann in die Drum;

        OncollisionEnter
        if(collider.tag(Player)
            Sound;
            Effekt;
            Endscreen after 5 seconds;


        // Update is called once per frame
        void Update()
        {
            if(everySOundmillconnectet.Raycasthit ==true)
            {


                Rotation.z = 25;                      
                IsEndingtrue = true; //evtl dann in playercontroller in das update && fixedupdate genau das abfragen am anfang ?

                oder das ganze in dem Script hier.
                if(isKeypressed(get.KeyCode(A) && isKeypressed(get.KeyCode(D))
                {
                    nothing happens
            }
        }*/
    }
