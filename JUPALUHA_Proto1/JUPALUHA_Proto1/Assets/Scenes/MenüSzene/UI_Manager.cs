using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Volume_Game : MonoBehaviour
{
    CharControllerPhysics charphy;
    public GameObject start;
    public GameObject pause;
   // public GameObject Powerjumpvis;

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Update()
    {
        if(charphy.pauseMenu == true)
        {
            //start= FindGameObjectsWithTag("Start");
            start = GameObject.FindGameObjectWithTag("Start");
            pause = GameObject.FindGameObjectWithTag("Pause");

            start.gameObject.SetActive(false);
            pause.gameObject.SetActive(true);          
        }
    }
}
