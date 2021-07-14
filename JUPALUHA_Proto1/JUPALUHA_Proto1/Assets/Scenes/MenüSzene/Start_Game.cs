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
    public GameObject LeereSpitze;
    public GameObject LeereSpitze02;

    public enum Peak { start, options, quit, none01, none02 }
    public Peak type;



    void Start()
    {
        StartSpitze.gameObject.SetActive(false);
        OptionSpitze.gameObject.SetActive(false);
        QuitSpitze.gameObject.SetActive(false);
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
                    break;
                case Peak.options:
                    Debug.Log("options");
                    OptionSpitze.gameObject.SetActive(true);
                    QuitSpitze.gameObject.SetActive(false);
                    StartSpitze.gameObject.SetActive(false);
                    break;
                case Peak.quit:
                    Debug.Log("quit");
                    QuitSpitze.gameObject.SetActive(true);
                    StartSpitze.gameObject.SetActive(false);
                    OptionSpitze.gameObject.SetActive(false);
                    break;
                case Peak.none01:
                    Debug.Log("none01");
                    StartSpitze.gameObject.SetActive(false);
                    OptionSpitze.gameObject.SetActive(false);
                    QuitSpitze.gameObject.SetActive(false);
                    break;
                case Peak.none02:
                    Debug.Log("none02");
                    StartSpitze.gameObject.SetActive(false);
                    OptionSpitze.gameObject.SetActive(false);
                    QuitSpitze.gameObject.SetActive(false);
                    break;
                default:
                    Debug.Log("NONE");
                    break;
            }
        }



    }

}
