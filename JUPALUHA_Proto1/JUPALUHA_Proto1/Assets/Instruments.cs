using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruments : MonoBehaviour
{
    public enum InteractionType {Second, Third, Fourth }
    public InteractionType type;

    public SoundmillRotation SoundmillScript;
    public Aktivator Aktivatorscript;
    public Drumzone Drumzonescript;

    static bool ShmolInstruAktiv;
    static bool AllinInstruAktiv;

    public bool connectetInstruaktiv;//Wichtig f�r Vents

    GameObject[] InstrumentenARRAY; //dot length oder so
    //Dictoniary

    public GameObject SecInstruSOUND;
    public GameObject ThirdInstruSOUND;
    public GameObject FourthInstruSOUND;
   
    public float Timer = 0;

    AudioSource SecInstru;
    AudioSource ThirdInstru;
    AudioSource FourthInstru;

    float shmolsound = 0.5f;
    float allInsound = 1f;

    int finaltimer = 0;

    public Material instrumaterial;

    // Start is called before the first frame update
    void Start()
    {
        SoundmillScript.GetComponent<SoundmillRotation>();
        Aktivatorscript.GetComponent<BoxCollider2D>();
        SecInstruSOUND.SetActive(true);
        ThirdInstruSOUND.SetActive(true);
        FourthInstruSOUND.SetActive(true);
        notaktivInstru();
    }
    void notaktivInstru ()
    {
        SecInstru = SecInstruSOUND.GetComponent<AudioSource>();
        ThirdInstru = ThirdInstruSOUND.GetComponent<AudioSource>();
        FourthInstru = FourthInstruSOUND.GetComponent<AudioSource>();

        SecInstru.volume = 0;
        ThirdInstru.volume = 0;
        FourthInstru.volume = 0;
    }
    // Update is called once per frame
    void Update()
    {    
        if (Aktivatorscript.AktivatorAktiv == true && SoundmillScript.isSoundtouching == true)
        {

            connectetInstruaktiv = true;
            ShmolInstruAktiv = true;

            if (Drumzonescript.isOpen == true)
            {
                connectetInstruaktiv = true;
                AllinInstruAktiv = true;
            }
        }
       else
       {
            connectetInstruaktiv = false;
            ShmolInstruAktiv = false;
            AllinInstruAktiv = false;
       }
        //notiz an mich, eher einfach rausschmei�en und ein neues objekt mit dem material der einen mini script beeinh�lt der einfach nur bis zu einem bestimmten wert z�hlt.
       // if (Input.GetKeyDown(KeyCode.X))//test shader
        //{
       //     Timer += Time.deltaTime;
        //    connectetInstruaktiv = true;
        //    ShmolInstruAktiv = true;
       // }
        Instrument();
    }
    void Instrument()
    {
        switch (type)
        {
            //case InteractionType.First:            
            //        break;

            case InteractionType.Second:

                if (ShmolInstruAktiv == true)
                {
                    //Debug.Log("3");
                    //Shader.SetGlobalFloat("_aktivatorfloat2", 3);
                    //Shader.SetGlobalFloat("_TimerInstru2", Timer);
                    if (AllinInstruAktiv == true)
                    {
                        SecInstru.volume = allInsound;
                        Debug.Log("allinsound works");
                    }
                    else
                    {
                        SecInstru.volume = shmolsound;
                        Debug.Log("shmol shmolsound works");
                    }
                }
                else
                  //  Shader.SetGlobalFloat("_aktivatorfloat2", 1);
                     SecInstru.volume = 0;
                break;

            case InteractionType.Third:
                if (ShmolInstruAktiv == true)
                {
                    Shader.SetGlobalFloat("_TimerInstru3", Timer);

                    if (AllinInstruAktiv == true)
                        ThirdInstru.volume = allInsound;
                    else
                        ThirdInstru.volume = shmolsound;
                }      
                else
                    ThirdInstru.volume = 0;
                break;

            case InteractionType.Fourth:
                if (ShmolInstruAktiv == true)
                {
                    Shader.SetGlobalFloat("_TimerInstru4", Timer);

                    if (AllinInstruAktiv == true)
                        FourthInstru.volume = allInsound;
                    else
                        FourthInstru.volume = shmolsound;
                }          
                else
                    FourthInstru.volume = 0;
                break;

            default:
               // Debug.Log("NONE");
                break;
        }
    }
}
