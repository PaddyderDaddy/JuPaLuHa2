using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDDRUMBUM : MonoBehaviour
{
    public NewEndingScript ending;
    public GameObject viseffektend;
    public bool GameFin = false;
    public bool GameFinandTimeFin = false;
    float Timer;

    public GameObject PowerjumpAUDIO;

    //public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        //EndScreen.SetActive(false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && ending.TheEndisnear == true)
        {
            Instantiate(PowerjumpAUDIO, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
            Instantiate(viseffektend, new Vector2(transform.position.x, transform.position.y +4f), Quaternion.Euler(0, 0, 90));
            GameFin = true;
            Vector3 campos = new Vector3(-2.2f, -75.5f, -71.4f);
            Camera.main.gameObject.transform.position = Vector3.MoveTowards(Camera.main.gameObject.transform.position, campos, 10 *Time.deltaTime);

           // Camera.main.gameObject.transform.position = 
               // new Vector3(-2.2f, -67.5f, -71.4f);
        }
        /*
        if (GameFinandTimeFin == true)
        {
            EndScreen.SetActive(true);
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if(GameFin==true && GameFinandTimeFin == false )
            Timer += Time.deltaTime;
        if (Timer > 5)
            GameFinandTimeFin = true;
    }
}
