using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameManager GameManagerScript;
    public CharControllerPhysics PlayerControlerScript;

    public GameObject CheckpointNumber;
    public GameObject CheckpointTopNumber;

    public int Playerrange = 1;

    public GameObject OtherCheckpointTop01;
    //public GameObject OtherCheckpointTop02;
    //public GameObject OtherCheckpointTop03;


    private void Start()
    {
        GameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        PlayerControlerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharControllerPhysics>();
        CheckpointTopNumber.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        //if (Vector3.Distance(pc.gameObject.transform.position, CheckpointNumber.transform.position) < Playerrange)
        //    CheckpointTopNumber.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        //if (Vector3.Distance(CheckpointNumber.gameObject.transform.position, pc.gameObject.transform.position) < Playerrange)
        //    Destroy(this.gameObject);

        //CheckpointTopNumber.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManagerScript.lastCheckPointPos = transform.position;
            CheckpointTopNumber.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.2f, 0, 1);

            OtherCheckpointTop01.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            //OtherCheckpointTop02.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            //OtherCheckpointTop03.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

        }

    }
}

