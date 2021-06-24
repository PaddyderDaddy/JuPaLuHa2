using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruments : MonoBehaviour
{
    public SoundmillRotation SoundmillScript;
    public Drumzone Drumjump;
    public bool Instrumentactiv;

    GameObject[] InstrumentenARRAY; //dot length oder so
    //Dictoniary
    public Transform InstrumentYellow;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SoundmillScript.GetComponent<SoundmillRotation>();
        Drumjump.GetComponent<Drumzone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Drumjump.isOpen == true && SoundmillScript.isSoundtouching == true)
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
            InstrumentYellow.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
        }

    }
    void Instrument()
    {
        InstrumentYellow.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }
}
