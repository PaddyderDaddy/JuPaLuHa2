using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentAktivatorA : MonoBehaviour
{
    public AudioSource audioSourceOne;
    public Drumzone DrumScript;
    public Drumzone DrumScriptleft;
    public float musicVolume = 0f;
    public float FadeTime = 5f;

    public bool startMusic;
    bool DONOTBOTHERME = false;
    private void Update()
    {
        audioSourceOne.volume = musicVolume;
        if (startMusic == true)
        {
            musicVolume += Time.deltaTime / FadeTime;

            if (musicVolume < 0.7f && DONOTBOTHERME == false)
            {
                if (musicVolume > 0.6f)
                {
                    musicVolume = 0.6f;
                    //musicVolume += 1f * Time.deltaTime;
                }
            }
            if (DrumScript.isOpen == true || DrumScriptleft.isOpen == true)
            {
                DONOTBOTHERME = true;
                musicVolume += Time.deltaTime / FadeTime;
                if (musicVolume > 1f)
                    musicVolume = 1;
            }
            if (DrumScript.isOpen == false && DrumScriptleft.isOpen == false)
            {
                musicVolume = 0.6f;
                DONOTBOTHERME = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            startMusic = true;
        }
    }
}
