using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllerPhysics : MonoBehaviour
{
    public Rigidbody2D ChaRigidbody;
    SpriteRenderer Renderer;
    BoxCollider2D ChaBoxCollider;

    public float MoveSpeed = 10;

    float xVelocity;

    public float jumpDelay = 0.25f;
    private float jumpTimer;

    public float OverlapBoxDistance = 0;
    public bool Grounded = false;

    //GRAB
    [Header("Grab")]
    public bool TouchingObject = false;
    public Vector2 upOffset;
    public float collisionRadius;
    public Color gizmoColor = Color.red;

    [Header("Gravity")]
    public float GravityNormal = -9.81f;

    //LEVER
    [Header("Lever")]
    public bool touchLever = false;

    //JUMP
    [Header("Jump Parameters")]
    bool Jumping = false;
    public float DropTimer;
    public float JumpForce;
    public bool wasGrounded = false;
    static bool Milljump; //ist drinnen weil der normale "jumping" bool ärger macht.
    //MOMENTUM JUMP
    public Transform grabDetect;
    //public Transform boxHolder; //bzw ich halte mich an dem objekt fest
    float rayDist;
    public float Momentumjumpmin = 20;
    GameObject PlayerObj;
    public Transform Player;
    public static Vector3 PlayerVector;

    //HOOK GRAB
    [Header("Hook Grab")]
    public Transform HookGrab;
    static bool direction = false;
    private Transform Target;
    bool HookDetect = false;
    public float FixeScale = 1;
    bool hookup = false;
    public float hookupheight = 1.1f;
    public Transform PLPO;
    public Transform HookVIS;
    public static bool grabbed = false;

    //SOUNDMILL
    [Header("Soundmill")]
    Rigidbody2D SoundRb;
    float Rotationdirection;
    Transform SoundmillObjekt; //ist nicht zugweisene
    float SoundOffsetAngle;
    float SoundOffsetAngleSavedPosition;
    public float Force;
    Vector2 SoundmillOffsetVector;
    float Angle;
    public bool PlayerattachedtoSoundmill;

    //Rotation
    [Header("Rotation")]
    Quaternion rotationPlayer; //idfk what that is
    Quaternion rotationPLPO;
    Quaternion rotationHookGrab;
    public bool IsOnSoundMill = false;
    public Vector3 PlayerVelocity;
    //CABLE CAR
    bool IsOnCableCar = false;
    Transform soundmill;

    //PARACUTE
    [Header("Paracute")]
    public Transform paracute;
    public GameObject Interaktiv;
    int ExtraGlide;

    //visuell
    public GameObject Powerjumpvis;
    public GameObject GrabVis;
   // public ParticleSystem ;
    static bool DidawesomeJump = false;
    private void Awake()
    {
        rotationPLPO = PLPO.transform.rotation;
        rotationPlayer = transform.rotation; //Damit verändert sich meine Rotation (i hope) nicht
        rotationHookGrab = HookGrab.transform.rotation;
    }

    void Start()
    {
        ChaRigidbody = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();
        ChaBoxCollider = GetComponent<BoxCollider2D>();

        Interaktiv.gameObject.SetActive(false);
        paracute.gameObject.SetActive(true);

       // Physics2D.IgnoreLayerCollision(7, 11);//ignore Soundmillrotor and player
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "CableCar" && IsOnSoundMill == false)
        {
            collision.collider.transform.SetParent(null);
        }
        if (collision.collider.tag == "SoundMillRotor")
        {
            IsOnSoundMill = false;
            Physics2D.IgnoreCollision(collision.collider, Player.GetComponent<Collider2D>());
        }
    }
    public void GrabHook()
    {
        if (direction == false && IsOnSoundMill == false)
            HookGrab.transform.localPosition = new Vector2(0.7f, hookupheight); //right up      
        if (direction == true && IsOnSoundMill == false)
            HookGrab.transform.localPosition = new Vector2(-0.7f, hookupheight); //left up            

        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist); //kann nur nach rechts schauen


        if (grabCheck.collider != null && grabCheck.collider.tag == "Pin")
        {
            SoundmillRotation currentSoundmill = grabCheck.collider.transform.parent.GetComponent<SoundmillRotation>();

            if (currentSoundmill != null)
                GameManager.instance.ActiveSoundmill = currentSoundmill;

            Debug.Log("Ich erkenne etwas");
            grabbed = true;
            PlayerVelocity = ChaRigidbody.velocity;

            //standart Kram
            IsOnSoundMill = true;
            ChaRigidbody.gravityScale = 0;
            xVelocity = 0;
            ChaRigidbody.velocity = new Vector2(0, 0);
            hookup = true;
            Milljump = false;
            Jumping = false;
            //Entparent
            Player.transform.parent = null;
            PLPO.transform.parent = null; //Nicht mehr Child des Hooks
            HookGrab.transform.parent = null; //nicht mehr Child des Players

            //Parenten                                           
            Target = grabCheck.collider.gameObject.GetComponent<Transform>();
            PLPO.transform.parent = Target.transform; //Parent = PIN
            HookGrab.transform.parent = PLPO.transform; //Child des PLPO          
            Player.transform.parent = HookGrab.transform; //Child des Hooks                  

            //Position
            PLPO.transform.localPosition = new Vector3(0, 0, 0);
            HookGrab.transform.localPosition = new Vector3(0, -0.4f, 0);
            Player.transform.localPosition = new Vector3(-0.7f, -hookupheight, 0); 
            //effect

            Instantiate(GrabVis, new Vector2(HookGrab.transform.position.x, HookGrab.transform.position.y), Quaternion.identity);
            //Ursprungspunkt
            //SoundmillOffset = Player.transform.root.GetComponent<Transform>();
            //SoundmillOffsetVector = SoundmillOffset.transform.position;
            // Debug.Log(SoundmillOffsetVector);        
            //Ursprungspunkt
            Rotation();
            HookDetect = true;
            PlayerattachedtoSoundmill = true;
        }
    }
    public void Rotation()
    {
        SoundmillObjekt = Target.transform.root.GetComponent<Transform>();

        //SoundmillObjekt = Target.transform.parent.GetComponent<Transform>();
        SoundRb = Target.root.GetComponent<Rigidbody2D>();
        Debug.Log("Targets Parent" + Target.transform.root.name);
        //Rigidbody2D SoundRb = Target.transform.parent.GetComponent<Rigidbody2D>();

        SoundmillOffsetVector = SoundmillObjekt.transform.position;

        //berechnet den Winkel des andockends
        Vector2 gloabalpinvector = Target.transform.position;
        Vector3 targetDir = gloabalpinvector - SoundmillOffsetVector;
        Angle = Vector3.Angle(targetDir, PlayerVelocity);
        //Debug.Log(string.Format("angle={0}", Angle));

        //In welche richtung soll sich die Soundmill drehen?
        float direction = 1;
        if (Player.position.x > SoundmillOffsetVector.x) //Right           
            if (PlayerVelocity.y < 0) //down
                direction = -1;

        if (Player.position.x < SoundmillOffsetVector.x) //Left
            if (PlayerVelocity.y > 0) //up
                direction = -1;
        SoundRb.angularVelocity += PlayerVelocity.sqrMagnitude * Mathf.Sin(Angle * Mathf.Deg2Rad) * direction; //hier wird der impuls aus dem Winkel und der Geschwindigleit berechnet     

        Force = SoundRb.angularVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CableCar" && IsOnSoundMill == false) //Sobald auf einer Soundmill/Grounded/oder E gedrückt wird = Ignore CableCar
        {
            if (IsOnSoundMill == true || Grounded == true || Input.GetKey(KeyCode.E))
            {
                collision = GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(collision, Player.GetComponent<Collider2D>());
                Debug.Log("IgnoredCollision");
            }
            else
            {
                Player.transform.parent = collision.transform; //Child des PLPO 
                ChaRigidbody.gravityScale = 0;
                ChaRigidbody.velocity = new Vector2(0, 0);
                Player.transform.localPosition = new Vector2(0, 0);
                IsOnCableCar = true;
            }
        }

        if (collision.gameObject.tag == "interaction")
        {
            OpenInteraktableIcon();
            touchLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "interaction")
        {
            CloseInteraktableIcon();
            touchLever = false;
        }

    }

    void FixedUpdate()
    {
        //GROUNDED
        Grounded = Physics2D.OverlapBox(ChaRigidbody.position + Vector2.up * OverlapBoxDistance, transform.localScale * 0.98f, 0, LayerMask.GetMask("Level"));
        TouchingObject = Physics2D.OverlapCircle((Vector2)transform.position + upOffset, collisionRadius, LayerMask.GetMask("GrabbableObject"));

        float xInput = Input.GetAxisRaw("Horizontal");

        float velocityDelta = 50;

        if (IsOnSoundMill == false) //nicht auf den Soundmills möglich !
            xVelocity = Mathf.MoveTowards(ChaRigidbody.velocity.x, xInput * MoveSpeed, velocityDelta * Time.deltaTime);

        //HookGrab
        if (xVelocity < 1f && Input.GetKey(KeyCode.A) && IsOnSoundMill == false)
        {
            HookGrab.transform.localPosition = new Vector2(-0.7f, 0); //left
            direction = true;
        }
        else if (xVelocity > 1f && IsOnSoundMill == false)
        {
            HookGrab.transform.localPosition = new Vector2(0.7f, 0); //right
            direction = false;
        }
        else if (xVelocity == 0 && IsOnSoundMill == false)
        {
            if (direction == false)
                HookGrab.transform.localPosition = new Vector2(0.7f, 0); //right
            if (direction == true)
                HookGrab.transform.localPosition = new Vector2(-0.7f, 0); //left
        }

        ChaRigidbody.velocity = new Vector2(xVelocity, ChaRigidbody.velocity.y);

        //cablecarjump
        if (Input.GetKey(KeyCode.Space) && IsOnCableCar == true)
        {
            IsOnCableCar = false;
            Player.transform.parent = null; // collision.transform.SetParent(null);               
            HookDetect = false;
            //Jumping = true;
            ChaRigidbody.gravityScale = 1;
            ChaRigidbody.velocity = new Vector3(0, JumpForce / 5);
        }
        //Soundmilljump
        if (Input.GetKey(KeyCode.Space) && IsOnSoundMill == true && !Input.GetKey(KeyCode.K))
            SoundmillJump();

        //Soundmillgrab
        if (Input.GetKey(KeyCode.K)) //funktioniert leider nicht wenn man das gedrückt hält... muss getestet werden ob das besser in "update" hineinkommt.
            GrabHook();
        
        //ONSOUNDMILL
        if (IsOnSoundMill == true)
        {
           // SoundOffsetAngleSavedPosition = SoundmillObjekt.transform.rotation.z;

            SoundOffsetAngleSavedPosition = SoundmillObjekt.transform.rotation.z;
            PLPO.transform.localPosition = new Vector3(0, 0, 0);
            HookGrab.transform.localPosition = new Vector3(0, -0.4f, 0);
            Player.transform.localPosition = new Vector3(-0.7f, -hookupheight, 0);
            ChaRigidbody.angularVelocity = 0;
        }      

        if (Grounded == true)
        {
            paracute.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            Jumping = false;
            DropTimer = 0;
            ExtraGlide = 1;
            Milljump = false;
            //viseffect
            if (DidawesomeJump == true)
            {
                //ChaRigidbody.position.
                Instantiate(Powerjumpvis, new Vector2(Player.transform.localPosition.x, Player.transform.localPosition.y-0.5f), Quaternion.identity);
                DidawesomeJump = false;
            }

        }
        
        if (Input.GetKey(KeyCode.LeftShift) && Grounded == false)
        {
            paracute.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    void SoundmillJump()
    {
        //Debug.Log(CurrentRotation);
        // Debug.Log(SoundOffsetAngle);
        //rotation
        SoundOffsetAngle = SoundmillObjekt.transform.rotation.z;
        //VERSTOßEN
        Player.transform.parent = null;
        PLPO.transform.parent = null; //Nicht mehr Child des Hooks
        HookGrab.transform.parent = null; //nicht mehr Child des Players
        //PARENTEN
        HookGrab.transform.parent = Player.transform; //Hook = Child des Player
        PLPO.transform.parent = HookGrab.transform;   //PLPO = Child des Hooks   
        HookGrab.transform.localPosition = new Vector3(-0.7f, 0, 0);
        PLPO.transform.localPosition = new Vector3(0, 0.4f, 0);

        //Jumping = true;
        hookup = false;
        HookDetect = false;
        ChaRigidbody.gravityScale = 1;
        if (SoundOffsetAngle < SoundOffsetAngleSavedPosition)
            Force *= -1;

        float normalized = Mathf.InverseLerp(0, 180, Force); //Damit habe ich eine Value zwischen ´0-1
        normalized = normalized * Momentumjumpmin;

        if (Input.GetKey(KeyCode.A))
            ChaRigidbody.velocity = new Vector3(-Mathf.Cos(-45), Mathf.Sin(45)) * normalized;

        if (Input.GetKey(KeyCode.D))
            ChaRigidbody.velocity = new Vector3(Mathf.Cos(-45), Mathf.Sin(45)) * normalized;
        
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            ChaRigidbody.velocity = new Vector3(0, normalized);

        Milljump = true;
        //Debug.Log("Normalized" + normalized);
        IsOnSoundMill = false;
    }

    void Update()
    {      
     
        //SIMPLE JUMP
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            jumpTimer = Time.deltaTime + jumpDelay;
            ChaRigidbody.velocity = Vector2.up * JumpForce;
            Jumping = true;
        }
        if(Milljump ==true)    
            jumpTimer = Time.deltaTime + jumpDelay;

        //Timer for Powerdrop
        if (Jumping == true || Milljump == true)
            DropTimer += Time.deltaTime;

        //POWER DROP
        if (Input.GetKey(KeyCode.I) && Jumping == true && DropTimer > 2 || Input.GetKey(KeyCode.I) && Milljump == true && DropTimer  > 1.5f)
        {
            ChaRigidbody.velocity = Vector2.down * JumpForce * 5;
            DidawesomeJump = true;
            //Debug.Log(ChaRigidbody.velocity);
        }
        //GLIDING
        bool currentlygliding=false;
        //start gliding
        if (Input.GetKeyDown(KeyCode.LeftShift) && Grounded == false) 
        {
            FindObjectOfType<Gliding>().StopGliding();
            paracute.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            currentlygliding = true;
        }
        //extragliding
        if (Input.GetKeyDown(KeyCode.LeftShift) && Grounded == false && ExtraGlide > 0 && currentlygliding == true)
        {
            FindObjectOfType<Gliding>().StartGliding();
            ExtraGlide--;
            currentlygliding = false;
        }

        if (Grounded == true)
        {
            FindObjectOfType<Gliding>().StopGliding();
            paracute.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    void LateUpdate()
    {
        transform.rotation = rotationPlayer;
        PLPO.transform.rotation = rotationPLPO;
        HookGrab.transform.rotation = rotationHookGrab;
    }

    public void OpenInteraktableIcon()
    {
        Interaktiv.gameObject.SetActive(true);
    }
    public void CloseInteraktableIcon()
    {
        Interaktiv.gameObject.SetActive(false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + upOffset, collisionRadius);
    }
}
