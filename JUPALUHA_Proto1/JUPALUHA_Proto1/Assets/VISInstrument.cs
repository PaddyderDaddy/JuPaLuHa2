using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VISInstrument : MonoBehaviour
{
    public enum InteractionType {First, Second, Third, Fourth }
    public InteractionType type;

    public float Timer = 0; 
    public float open = 1;//wird hiereinmal auf 1 gesetzt damit der einmal in den Instrumenten code geht
    public Instruments instrumentscript;
    bool instruwasturnedon =false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (instrumentscript.connectetInstruaktiv == true) 
        {
            Debug.Log("erstesLevel");
            if (Timer <= 5) //langsamer glow effekt durch den Timer
                Timer += Time.deltaTime;

            Instrument();
           
        }
        if (instrumentscript.connectetInstruaktiv == false)
        {
            if(Timer!=0 || open!=0)
            {
                instruwasturnedon = false;
                if (Timer >= 0) //langsamer Fade weg
                    Timer -= Time.deltaTime;
                if (Timer <= 0)
                    open = 0;
                Instrument();
            }         
        }
    }
    //als nächstes die anderen Shader und auf die  anderen Scripte
    void Instrument()
    {
        switch (type)
        {
            case InteractionType.First:
                Shader.SetGlobalFloat("_aktivatorfloat2", 1);
                Shader.SetGlobalFloat("_TimerInstru2", Timer);
                break;
            
            case InteractionType.Second:

                if (instruwasturnedon == false && instrumentscript.connectetInstruaktiv == true) //sobald einmal aktiv gewesen und Instru true:
                {
                    open = 1;
                    instruwasturnedon = true;
                    Debug.Log("eigentlich soll er jetzt blinken");                  
                    Debug.Log("zweitesLevel");
                }
                //wird immer gesetzt
                Shader.SetGlobalFloat("_InstruaktivTimer2", Timer);
                Shader.SetGlobalFloat("_Lightaktiv2", open);

                break;

            case InteractionType.Third:
              
                break;

            case InteractionType.Fourth:
           
                break;

            default:
                // Debug.Log("NONE");
                break;
        }
    }
}
