using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pausemenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer audioMixer;
    public GameObject Endscreen;

    public ENDDRUMBUM Endscript;
    public GameObject EndMenuUi;
    bool endee;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
                Resume();
            else
                Pause();

        }
        
        if(Endscript.GameFinandTimeFin == true)
        {
            EndMenuUi.SetActive(true);

            Time.timeScale = 0f;
            //GameIsPaused = true;
            //Endscreen.SetActive(true);
        }
    }
    public void ende()
    {

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menü");
    }

    public void Volume(float volume)
    {
        //audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        audioMixer.SetFloat("Volume", volume);
        //Debug.Log(volume);

    }
}

