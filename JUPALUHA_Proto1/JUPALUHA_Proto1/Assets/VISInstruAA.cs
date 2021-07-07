using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VISInstruAA : MonoBehaviour
{
    public float Timer = 0;
    public float open = 1;
    public InstrumentAktivatorA instruAaktiv;
    bool instruAAwasturnedon = false;
    bool currentstateaktiv = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (instruAaktiv.connectetInstruaktivA == true)
        {
            currentstateaktiv = true;
        }

        if (currentstateaktiv == true)
        {
            Debug.Log("erstesLevel");
            if (Timer <= 5) //langsamer glow effekt durch den Timer
                Timer += Time.deltaTime;

            Instrument();

        }
        if (currentstateaktiv == false)
        {
            if (Timer != 0 || open != 0)
            {
                instruAAwasturnedon = false;
                if (Timer >= 0) //langsamer Fade weg
                    Timer -= Time.deltaTime;
                if (Timer <= 0)
                    open = 0;
                Instrument();
            }
        }
    }
    void Instrument()
    {


        if (instruAAwasturnedon == false && currentstateaktiv == true) //sobald einmal aktiv gewesen und Instru true:
        {
            open = 1;
            instruAAwasturnedon = true;
        }
        Shader.SetGlobalFloat("_aktivatorfloat1", 1);
        Shader.SetGlobalFloat("_TimerInstru1", Timer);
    }
}
