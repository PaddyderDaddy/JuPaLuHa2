using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePlayer : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = gm.lastCheckPointPos;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //        //cm.gameObject.transform.position = gm.lastCheckPointPos;
    //        //cm.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -10f);
    //        //cm.cameraposition = gm.lastCheckPointPos;
    //    }

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
