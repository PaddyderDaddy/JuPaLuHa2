using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Volume_Game : MonoBehaviour
{
    Start_Game startgame;

    CharControllerPhysics charphy;
    public GameObject start;
    public GameObject pause;
    // public GameObject Powerjumpvis;

    public Animator animator;
    public float seconds;

    [SerializeField]
    GameObject picture;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(levelIndex);
    }
}
