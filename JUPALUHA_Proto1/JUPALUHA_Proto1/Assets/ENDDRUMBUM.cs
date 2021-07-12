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
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && ending.TheEndisnear == true)
        {
            Instantiate(viseffektend, new Vector2(transform.position.x, transform.position.y +4f), Quaternion.Euler(-0.113f, -90f, 90));
            GameFin = true;
        }

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
