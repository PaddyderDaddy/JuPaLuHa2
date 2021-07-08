using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VISFlagdissolve : MonoBehaviour
{
    public enum InteractionType {First, Second, Third, Fourth }
    public InteractionType type;

    public float Timer = 0;
    public float open = 0; //wird hiereinmal auf 1 gesetzt damit der einmal in den Instrumenten code geht
    public Aktivator aktivatorscript;
    public InstrumentAktivatorA aktivatorAscript;
    // Start is called before the first frame update
    void Start()
    {
         Timer = 0;
        Shader.SetGlobalFloat("_Flag1time", Timer);
        Shader.SetGlobalFloat("_Flag2time", Timer);
        Shader.SetGlobalFloat("_Flag3Time", Timer);
        Shader.SetGlobalFloat("_Flag4time", Timer);

    }

    // Update is called once per frame
    void Update()
    {
        if(aktivatorscript.AktivatorAktiv == true/*|| aktivatorAscript.*/)
        {
            flagdissolve();
            if (Timer <= 5) //langsamer glow effekt durch den Timer
                Timer += Time.deltaTime;
        }
    }
    void flagdissolve()
    {
        switch (type)
        {
            case InteractionType.First:
                Shader.SetGlobalFloat("_Flag1time", Timer);
                break;

            case InteractionType.Second:             
                Shader.SetGlobalFloat("_Flag2time", Timer);
                break;

            case InteractionType.Third:
                Shader.SetGlobalFloat("_Flag3Time", Timer);
                break;

            case InteractionType.Fourth:
                Shader.SetGlobalFloat("_Flag4time", Timer);
                break;

            default:
                // Debug.Log("NONE");
                break;
        }
    }
}

