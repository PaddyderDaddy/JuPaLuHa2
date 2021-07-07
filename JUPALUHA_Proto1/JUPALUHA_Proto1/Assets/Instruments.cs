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

    public bool connectetInstruaktiv;//Wichtig für Vents

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
                     SecInstru.volume = 0;
                break;

            case InteractionType.Third:

                if (ShmolInstruAktiv == true)
                {
                    if (AllinInstruAktiv == true)
                    {
                        SecInstru.volume = allInsound;
                    }
                    else
                    {
                        SecInstru.volume = shmolsound;
                    }
                }
                else
                    SecInstru.volume = 0;
                break;

            case InteractionType.Fourth:
                if (ShmolInstruAktiv == true)
                {
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
