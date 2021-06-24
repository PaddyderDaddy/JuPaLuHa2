using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruments : MonoBehaviour
{
    public enum InteractionType { First, Second, Third, Fourth }
    public InteractionType type;

    public SoundmillRotation SoundmillScript;
    public Aktivator Aktivatorscript;
    public bool Instrumentactiv;

    GameObject[] InstrumentenARRAY; //dot length oder so
    //Dictoniary

    public GameObject FirstInstruSOUND;
    public GameObject SecInstruSOUND;
    public GameObject ThirdInstruSOUND;
    public GameObject FourthInstruSOUND;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SoundmillScript.GetComponent<SoundmillRotation>();
        Aktivatorscript.GetComponent<BoxCollider2D>();
        FirstInstruSOUND.SetActive(true);
        SecInstruSOUND.SetActive(false);
        ThirdInstruSOUND.SetActive(false);
        FourthInstruSOUND.SetActive(false);

    }
    void aktiv()
    {    

    }
   
    // Update is called once per frame
    void Update()
    {
        if (Aktivatorscript.AktivatorAktiv == true && SoundmillScript.isSoundtouching == true)
        {
            //Timer += Time.deltaTime;
            //if (Timer <= 3)
            //{
            //    Instrumentactiv = true;
            //    Instrument();
            //}
            //else if (Timer > 3)
            //    Timer = 0;
            Instrumentactiv = true;
            Instrument();

            
        }
        else
        {
            Instrumentactiv = false;
            //InstrumentYellow.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
        }

    }
    void Instrument()
    {
        //InstrumentYellow.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        switch (type)
        {
            case InteractionType.First:
                FirstInstruSOUND.SetActive(true);
                break;
            case InteractionType.Second:
                SecInstruSOUND.gameObject.SetActive(true);
                break;
            case InteractionType.Third:
                ThirdInstruSOUND.SetActive(true);
                break;
            case InteractionType.Fourth:
                FourthInstruSOUND.SetActive(true);
                break;
            default:
                Debug.Log("NONE");
                break;
        }
    }
}
