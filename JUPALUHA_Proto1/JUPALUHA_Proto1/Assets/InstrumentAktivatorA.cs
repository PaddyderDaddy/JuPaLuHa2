using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentAktivatorA : MonoBehaviour
{
    public AudioSource audioSourceOne;
    public float musicVolume = 0f;
    public float FadeTime = 5f;

    public bool startMusic;

    private void Update()
    {
        audioSourceOne.volume = musicVolume;

        if(startMusic == true)
        {
            musicVolume += Time.deltaTime / FadeTime;

            if (musicVolume > 1)
            {
                musicVolume = 1;
                //musicVolume += 1f * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            startMusic = true;
        }
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }

}
