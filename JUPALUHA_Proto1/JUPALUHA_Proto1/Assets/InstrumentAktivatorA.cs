using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentAktivatorA : MonoBehaviour
{
    public bool connectetInstruaktivA;//Wichtig für Vents

    public AudioSource audioSourceOne;
    public Drumzone DrumScript;
    public Drumzone DrumScriptleft;
    public float musicVolume = 0f;
    public float FadeTime = 5f;

    public bool startMusic;
    bool DONOTBOTHERME = false;

    public CharControllerPhysics Char;

    public AudioSource Voice;
    public GameObject Voiceobj;

    public GameObject pressU;
    public GameObject Triggerzonesinging;


    private void Start()
    {
        audioSourceOne.volume = 0;
        Voice.volume = 0;

        Voiceobj.gameObject.SetActive(false);
        pressU.gameObject.SetActive(false);

    }
    private void Update()
    {
        audioSourceOne.volume = musicVolume;

        if (startMusic == true)
        {
            connectetInstruaktivA = true;

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
        if (Input.GetKeyDown(KeyCode.U) && Char.isinSingingZone == true)
        {
            pressU.gameObject.SetActive(false);
            Destroy(Triggerzonesinging);
            StartCoroutine(Wait());
        }

        if (Char.isinSingingZone == true)
            pressU.gameObject.SetActive(true);

        if (Char.isinSingingZone == false)
            pressU.gameObject.SetActive(false);
    }

    IEnumerator Wait()
    {
        Char.transform.localScale = new Vector3(-0.75f, 1.75f, 1);
     
        Char.animator.SetTrigger("Singing");
        Voiceobj.gameObject.SetActive(true);
        Voice.volume = 1;
      
        yield return new WaitForSeconds(6f);
        Voice.volume = 0;

        startMusic = true;

    }
}