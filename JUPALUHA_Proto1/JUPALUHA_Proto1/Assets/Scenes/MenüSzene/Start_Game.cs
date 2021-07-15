using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    RotationMenu rotationMenuScript;
    UI_Manager ui;

    public GameObject StartSpitze;
    public GameObject OptionSpitze;
    public GameObject QuitSpitze;
    public GameObject Tutorial;
    public GameObject Credits;

   // public Pausemenu ProbeSzeneUIscript;
    public enum Peak { start, options, quit, Tutorial, Credits }
    public Peak type;



    void Start()
    {
        StartSpitze.gameObject.SetActive(false);
        OptionSpitze.gameObject.SetActive(false);
        QuitSpitze.gameObject.SetActive(false);
        Tutorial.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
    }
    private void Update()
    {
        /*
        if(ProbeSzeneUIscript.gameisreallyFIN == true)
        {
            StartSpitze.gameObject.SetActive(false);
            OptionSpitze.gameObject.SetActive(false);
            QuitSpitze.gameObject.SetActive(false);
            Tutorial.gameObject.SetActive(false);
            Credits.gameObject.SetActive(false);
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Menutrigger")
        {
            switch (type)
            {
                case Peak.start:
                    Debug.Log("start"); 
                    StartSpitze.gameObject.SetActive(true);

                    OptionSpitze.gameObject.SetActive(false);
                    QuitSpitze.gameObject.SetActive(false);
                    Tutorial.gameObject.SetActive(false);
                    Credits.gameObject.SetActive(false);
                    break;
                case Peak.options:
                    Debug.Log("options");
                    OptionSpitze.gameObject.SetActive(true);

                    QuitSpitze.gameObject.SetActive(false);
                    StartSpitze.gameObject.SetActive(false);
                    Tutorial.gameObject.SetActive(false);
                    Credits.gameObject.SetActive(false);
                    break;
                case Peak.quit:
                    Debug.Log("quit");
                    QuitSpitze.gameObject.SetActive(true);

                    StartSpitze.gameObject.SetActive(false);
                    OptionSpitze.gameObject.SetActive(false);
                    Tutorial.gameObject.SetActive(false);
                    Credits.gameObject.SetActive(false);
                    break;
                case Peak.Tutorial:
                    Debug.Log("none01");
                    Tutorial.gameObject.SetActive(true);

                    StartSpitze.gameObject.SetActive(false);
                    OptionSpitze.gameObject.SetActive(false);
                    QuitSpitze.gameObject.SetActive(false);
                    Credits.gameObject.SetActive(false);
                    break;
                case Peak.Credits:
                    Debug.Log("none02");
                    Credits.gameObject.SetActive(true);

                    StartSpitze.gameObject.SetActive(false);
                    OptionSpitze.gameObject.SetActive(false);
                    QuitSpitze.gameObject.SetActive(false);
                    Tutorial.gameObject.SetActive(false);
                    break;
                default:
                    Debug.Log("NONE");
                    break;
            }
        }



    }

}
