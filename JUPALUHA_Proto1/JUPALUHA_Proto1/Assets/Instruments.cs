using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruments : MonoBehaviour
{
    public enum InteractionType { First, Second, Third, Fourth }
    public InteractionType type;

    public SoundmillRotation SoundmillScript;
    public Aktivator Aktivatorscript;
    public Drumzone Drumzonescript;

    static bool ShmolInstruAktiv;
    static bool AllinInstruAktiv;

    GameObject[] InstrumentenARRAY; //dot length oder so
    //Dictoniary

    public GameObject FirstInstruSOUND;
    public GameObject SecInstruSOUND;
    public GameObject ThirdInstruSOUND;
    public GameObject FourthInstruSOUND;
   
    public float Timer = 0;

    AudioSource FirstInstru;
    AudioSource SecInstru;
    AudioSource ThirdInstru;
    AudioSource FourthInstru;

    float shmolsound = 0.5f;
    float allInsound = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SoundmillScript.GetComponent<SoundmillRotation>();
        Aktivatorscript.GetComponent<BoxCollider2D>();
        FirstInstruSOUND.SetActive(true);
        SecInstruSOUND.SetActive(true);
        ThirdInstruSOUND.SetActive(true);
        FourthInstruSOUND.SetActive(true);
        notaktivInstru();
    }
    void notaktivInstru ()
    {
        FirstInstruSOUND.GetComponent<AudioBehaviour>();

        FirstInstru = FirstInstruSOUND.GetComponent<AudioSource>();
        SecInstru = SecInstruSOUND.GetComponent<AudioSource>();
        ThirdInstru = ThirdInstruSOUND.GetComponent<AudioSource>();
        FourthInstru = FourthInstruSOUND.GetComponent<AudioSource>();

        FirstInstru.volume = 0;
        SecInstru.volume = 0;
        ThirdInstru.volume = 0;
        FourthInstru.volume = 0;
    }
    void aktiv()
    {    

    }
   
    // Update is called once per frame
    void Update()
    {
        if (Aktivatorscript.AktivatorAktiv == true && SoundmillScript.isSoundtouching == true)
        {
            ShmolInstruAktiv = true;
            if (Drumzonescript.isOpen == true)
            {
                AllinInstruAktiv = true;
            }
        }
        else
        {
            ShmolInstruAktiv = false;
            AllinInstruAktiv = false;
        }
        Instrument();
    }
    void Instrument()
    {
        switch (type)
        {
            case InteractionType.First:            
                    break;

            case InteractionType.Second:
                if (ShmolInstruAktiv == true)
                {
                    if (AllinInstruAktiv == true)
                        SecInstru.volume = allInsound;
                    else
                        SecInstru.volume = shmolsound;
                }
                else
                    SecInstru.volume = 0;

                break;
            case InteractionType.Third:
                if (ShmolInstruAktiv == true)
                {
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
                    if (AllinInstruAktiv == true)
                        FourthInstru.volume = allInsound;
                    else
                        FourthInstru.volume = shmolsound;
                }          
                else
                    FourthInstru.volume = 0;

                break;
            default:
                Debug.Log("NONE");
                break;
        }
    }
}
