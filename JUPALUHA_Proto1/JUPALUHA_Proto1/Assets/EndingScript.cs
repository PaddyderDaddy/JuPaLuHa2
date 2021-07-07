using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    Drumzone DrumzoneScript;
    Instruments InstrumentsScript;
    public InstrumentAktivatorA InstrumentsAktivatorAScript;
    Aktivator AktivatorScript;
    CharControllerPhysics CharControllerPhysicsScript;
    SoundmillRotation SoundmillRotationScript;

    public GameObject GiantDrum;
    public GameObject DissonanzCloud;
    public GameObject GiantSoundmill;

    public GameObject SecInstruSOUND;
    public GameObject ThirdInstruSOUND;
    public GameObject FourthInstruSOUND;

    public GameObject FiveInstruSOUND;

    public float Timer = 0;

    AudioSource SecInstru;
    AudioSource ThirdInstru;
    AudioSource FourthInstru;

    AudioSource FiveInstru;

    public bool AllSoundsLoud = false;
    public float FadeTime = 5;

    public GameObject DrumTrigger;

    //public Rigidbody2D rb;


    public void Start()
    {
        SecInstruSOUND.SetActive(true);
        ThirdInstruSOUND.SetActive(true);
        FourthInstruSOUND.SetActive(true);
        FiveInstruSOUND.SetActive(true);
        notaktivInstru();

        DissonanzCloud.gameObject.SetActive(true);

        //rb = GetComponent<Rigidbody2D>();
        //GiantSoundmill.gameObject.SoundmillRotationScript.rb.angularVelocity
    }

    void notaktivInstru()
    {
        SecInstru = SecInstruSOUND.GetComponent<AudioSource>();
        ThirdInstru = ThirdInstruSOUND.GetComponent<AudioSource>();
        FourthInstru = FourthInstruSOUND.GetComponent<AudioSource>();
        FiveInstru = FourthInstruSOUND.GetComponent<AudioSource>();

        SecInstru.volume = 0;
        ThirdInstru.volume = 0;
        FourthInstru.volume = 0;
        FiveInstru.volume = 0;
    }

    public void Update()
    {
        if (InstrumentsAktivatorAScript.musicVolume > 0.5 && SecInstru.volume > 0.5 && ThirdInstru.volume > 0.5 && FourthInstru.volume > 0.5)
        {
            AllSoundsLoud = true;
            StartCoroutine(DramaticPause());

            FiveInstru.volume += Time.deltaTime / FadeTime;
            if (FiveInstru.volume > 1f)
                FiveInstru.volume = 1;

        }

        if (AllSoundsLoud == true) // && Soundmill dreht sich 
        {
            DissonanzCloud.gameObject.SetActive(false);

            Time.timeScale = 0f;
            Camera.main.gameObject.transform.position = new Vector3(-2.2f, -35.1f, -10);
            StartCoroutine(DramaticPause());
            Camera.main.gameObject.transform.position = new Vector3(-2.2f, 92.043f, -10);
        }
    }

    IEnumerator DramaticPause()
    {
        yield return new WaitForSeconds(3f);
    }

    //macht alle Instrumente an + obere Soundmill -> Pause -> Camera nach unten -> Soundcloud verschwunden -> möglichkeit auf die Trommel zu springen -> Text (winner)
    //    -> durch alle sachen durchspringen (alles ignorieren)
    //    -> letzer soundmill macht ne Taste (T) und dann 
    // -> wenn i


    // steht oben auf der platform -> text erscheint -> t drücken -> kamera zoomt rein -> springt runter + kamera zoomt raus ->
    // fliegt durch alles durch und trifft auf trommel auf -> schwarzer bildschirm + sound + nur color

}
