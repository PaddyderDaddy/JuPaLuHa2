using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UI_Manager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void Start()
    {
        
    }
    public void QuitGame()
    {
        Debug.Log("byebye");
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1/*SceneManager.GetActiveScene().buildIndex + 1*/);
    }

    public void Volume(float volume)
    {
        //audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);

    }
}
