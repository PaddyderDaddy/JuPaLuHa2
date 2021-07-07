using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    //public GameObject FourthInstruSOUND;

    public GameObject FiveInstruSOUND;

    public float Timer = 0;

    AudioSource SecInstru;
    AudioSource ThirdInstru;
    //AudioSource FourthInstru;

    AudioSource FiveInstru;

    public bool AllSoundsLoud = false;
    public float FadeTime = 5;

    public GameObject DrumTrigger;

    //public float zoomSpeed = 1;
    //public float targetOrtho;
    //public float smoothSpeed = 2.0f;
    //public float minOrtho = 1.0f;
    //public float maxOrtho = 20.0f;
    //public Rigidbody2D rb;

    public bool isfiveon = false;


    public void Start()
    {
        notaktivInstru();

        DissonanzCloud.gameObject.SetActive(true);

        //rb = GetComponent<Rigidbody2D>();
        //GiantSoundmill.gameObject.SoundmillRotationScript.rb.angularVelocity
        //targetOrtho = Camera.main.orthographicSize;
    }

    void notaktivInstru()
    {
        SecInstru = SecInstruSOUND.GetComponent<AudioSource>();
        ThirdInstru = ThirdInstruSOUND.GetComponent<AudioSource>();
        //FourthInstru = FourthInstruSOUND.GetComponent<AudioSource>();
        FiveInstru = FiveInstruSOUND.GetComponent<AudioSource>();

    }

    public void Update()
    {
        if (InstrumentsAktivatorAScript.musicVolume > 0 && SecInstru.volume > 0 && ThirdInstru.volume > 0)// && FourthInstru.volume > 0.5)
        {
            AllSoundsLoud = true;
            StartCoroutine(DramaticPause());

            
        }

        if (AllSoundsLoud == true) // && Soundmill dreht sich 
        {
            DissonanzCloud.gameObject.SetActive(false);

            FiveInstru.volume += Time.deltaTime / FadeTime;
            if (FiveInstru.volume > 1f)
                FiveInstru.volume = 1;
            isfiveon = true;

            Time.timeScale = 0f; //bewegung ausschalten
            Camera.main.gameObject.transform.position = new Vector3(-2.2f, -35.1f, -10);
            StartCoroutine(DramaticPause());
            Camera.main.gameObject.transform.position = new Vector3(-2.2f, 92.043f, -10);
        }

        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //if (scroll != 0.0f)
        //{
        //    targetOrtho -= scroll * zoomSpeed;
        //    targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        //}

        //Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }

    IEnumerator DramaticPause()
    {
        yield return new WaitForSeconds(3f);
    }

}


    //macht alle Instrumente an + obere Soundmill -> Pause -> Camera nach unten -> Soundcloud verschwunden -> möglichkeit auf die Trommel zu springen -> Text (winner)
    //    -> durch alle sachen durchspringen (alles ignorieren)
    //    -> letzer soundmill macht ne Taste (T) und dann 
    // -> wenn i


    // steht oben auf der platform -> text erscheint -> t drücken -> kamera zoomt rein -> springt runter + kamera zoomt raus ->
    // fliegt durch alles durch und trifft auf trommel auf -> schwarzer bildschirm + sound + nur color

    //beim fall: kameramovement verschnellern, x-bewegung locken, zoom

// soundwolke weg wenn viertes instrument an -> sound 5 wenn man runterspringt.