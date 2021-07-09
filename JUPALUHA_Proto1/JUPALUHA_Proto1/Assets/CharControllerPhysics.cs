using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControllerPhysics : MonoBehaviour
{
    public Rigidbody2D ChaRigidbody;
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
    public Transform grabDetect;
    float rayDist;

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
    [Header("MOMENTUM JUMP")]
    float Momentumjumpmin = 20;
    GameObject PlayerObj;
    public Transform Player;
    static Vector3 PlayerVector;

    //HOOK GRAB
    [Header("Hook Grab")]
    public Transform HookGrab;
    static bool facingLeft = false;
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
    //public SoundmillRotation SoundmillRotationScript;
    Rigidbody2D SoundRb;
    float Rotationdirection;
    Transform SoundmillObjekt; //ist nicht zugweisene
    float SoundOffsetAngle;
    float SoundOffsetAngleSavedPosition;
    public float Force;
    Vector2 SoundmillOffsetVector;
    float Angle;
    public bool PlayerattachedtoSoundmill;
    SoundmillRotation Soundmillscript;
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
    [Header("Visuellobjects")]
    public GameObject Powerjumpvis;
    public GameObject GrabVis;

    [Header("menu")]
    public bool pauseMenu = false;

    // public ParticleSystem ;
    public bool DidawesomeJump = false;

    public bool isOnPendulum = false;

    private void Awake()
    {
        rotationPLPO = PLPO.transform.rotation;
        rotationPlayer = transform.rotation; //Damit verändert sich meine Rotation (i hope) nicht
        rotationHookGrab = HookGrab.transform.rotation;
    }

    void Start()
    {
        ChaRigidbody = GetComponent<Rigidbody2D>();
        

        Interaktiv.gameObject.SetActive(false);
        paracute.gameObject.SetActive(true);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "CollisionObject" && IsOnSoundMill == true)
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

            hookup = false;
            HookDetect = false;
            ChaRigidbody.gravityScale = 1;
            IsOnSoundMill = false;

        }
    }
    public void GrabHook()
    {
        if (facingLeft == false && IsOnSoundMill == false)
            HookGrab.transform.localPosition = new Vector2(0.7f, hookupheight); //right up      
        if (facingLeft == true && IsOnSoundMill == false)
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
            DropTimer = 0;

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
            if(currentSoundmill.isSoundtouching == false)
                Rotation();
        
            HookDetect = true;
            PlayerattachedtoSoundmill = true;
        }

        if (grabCheck.collider != null && grabCheck.collider.tag == "PinPendulum")
        {
            Pendulum currentPendulum = grabCheck.collider.transform.parent.GetComponent<Pendulum>();

            if (currentPendulum != null)
                GameManager.instance.ActivePendulum = currentPendulum;

            grabbed = true;
            PlayerVelocity = ChaRigidbody.velocity;

            //standart Kram
            isOnPendulum = true;
            ChaRigidbody.gravityScale = 0;
            xVelocity = 0;
            ChaRigidbody.velocity = new Vector2(0, 0);
            hookup = true;
            Jumping = false;
            DropTimer = 0;
            Milljump = false;

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

            HookDetect = true;
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
            HookGrab.transform.localPosition = new Vector2(-7, 20); //left
            facingLeft = true;
        }
        else if (xVelocity > 1f && IsOnSoundMill == false)
        {
            HookGrab.transform.localPosition = new Vector2(7, 20); //right
            facingLeft = false;
        }
        else if (xVelocity == 0 && IsOnSoundMill == false)
        {
            if (facingLeft == false)
                HookGrab.transform.localPosition = new Vector2(7, 20); //right
            if (facingLeft == true)
                HookGrab.transform.localPosition = new Vector2(-7, 20); //left
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

        //ONPENDULUM
        if (isOnPendulum == true)
        {
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
            DropTimer = 0;
            //viseffect
            if (DidawesomeJump == true)
            {
                //ChaRigidbody.position.
                Instantiate(Powerjumpvis, new Vector2(Player.transform.position.x, Player.transform.position.y-0.5f), Quaternion.Euler(-0.113f, -90f, 90));
                DidawesomeJump = false;
            }

        }
        
        if (Input.GetKey(KeyCode.LeftShift) && Grounded == false)
        {
            paracute.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        //Soundmilljump
        if (Input.GetKey(KeyCode.Space) && IsOnSoundMill == true && !Input.GetKey(KeyCode.K))
            SoundmillJump();

        if (Input.GetKey(KeyCode.Space) && isOnPendulum && !Input.GetKey(KeyCode.K))
            PendulumJump();
    }

    void SoundmillJump()
    {
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

        hookup = false;
        HookDetect = false;
        ChaRigidbody.gravityScale = 1;

        //Jumplogic
        float normalized;
         if (Force < 0)
            Force *= -1;
        normalized = Mathf.InverseLerp(-180f, 180f, Force); //Damit habe ich eine Value zwischen ´0-1      
        normalized = normalized * Momentumjumpmin;
        //Jumpsteuerung
        if (Input.GetKey(KeyCode.A))
            ChaRigidbody.velocity = new Vector3(-Mathf.Cos(-45), Mathf.Sin(45)) * normalized;
        if (Input.GetKey(KeyCode.D))
            ChaRigidbody.velocity = new Vector3(Mathf.Cos(-45), Mathf.Sin(45)) * normalized;       
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            ChaRigidbody.velocity = new Vector3(0, normalized);

        //other stuff
        DropTimer = 0; //mal schauen
        Milljump = true;
        IsOnSoundMill = false;
    }

    void PendulumJump()
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

        hookup = false;
        HookDetect = false;
        ChaRigidbody.gravityScale = 1;

        if (Input.GetKey(KeyCode.A))
            ChaRigidbody.velocity = new Vector3(-Mathf.Cos(-45), Mathf.Sin(45) * JumpForce);
        if (Input.GetKey(KeyCode.D))
            ChaRigidbody.velocity = new Vector3(Mathf.Cos(-45), Mathf.Sin(45) * JumpForce);
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            ChaRigidbody.velocity = new Vector3(0, JumpForce);


        isOnPendulum = false;
    }

    void Update()
    {
        if (isOnPendulum)
            Debug.Log("is on Pendulum");

        //Soundmillgrab
        if (Input.GetKey(KeyCode.K)&& IsOnSoundMill==false && isOnPendulum ==false) //funktioniert leider nicht wenn man das gedrückt hält... muss getestet werden ob das besser in "update" hineinkommt.
            GrabHook();

        //SIMPLE JUMP
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            jumpTimer = Time.deltaTime + jumpDelay;
            ChaRigidbody.velocity = Vector2.up * JumpForce;
            Jumping = true;
        }
        if(Jumping == true)    
            jumpTimer = Time.deltaTime + jumpDelay;     

        //POWERDROP
        if (/*Jumping == true ||*/ Milljump == true)
        {
            DropTimer += Time.deltaTime;
        }
      
        //POWER DROP
        if (Input.GetKey(KeyCode.Space) && Milljump == true && DropTimer > 1.5f /*Input.GetKey(KeyCode.L) && Jumping == true && DropTimer > 2 || */)
        {
            ChaRigidbody.velocity = Vector2.down * JumpForce * 5;
            DidawesomeJump = true;
            Milljump = false;
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

        //if (Jumping == false || Milljump == false || Milljump == false && Jumping == false)
           // DropTimer = 0;

        Shader.SetGlobalFloat("_AvaiblePowerjump", DropTimer);

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
