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
            Instrumentactiv = true;
            Instrument();
        }
        else
            Instrumentactiv = false;
    }
    void Instrument()
    {

    }
}
