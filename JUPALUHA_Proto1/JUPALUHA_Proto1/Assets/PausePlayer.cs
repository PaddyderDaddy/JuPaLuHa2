using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePlayer : MonoBehaviour
{
    private GameManager gm;
    private CameraFollow cf;

    private int currentSceneIndex;

    private int Timer = 0;
    public GameObject DeathSound;
    Animator animator;
    public bool Deathtrue;

    public GameObject firstSound;
    public GameObject SecInstruSOUND;
    public GameObject ThirdInstruSOUND;
    public GameObject FourthInstruSOUND;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = gm.lastCheckPointPos;

        animator = GetComponentInChildren<Animator>();
        DeathSound.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SoundTrigger")
        {

            firstSound.SetActive(false);
            SecInstruSOUND.SetActive(false);
            ThirdInstruSOUND.SetActive(false);
            FourthInstruSOUND.SetActive(false);

            Deathtrue = true;
            Instantiate(DeathSound, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
            DeathSound.gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Trigger")
        {
            firstSound.SetActive(true);
            SecInstruSOUND.SetActive(true);
            ThirdInstruSOUND.SetActive(true);
            FourthInstruSOUND.SetActive(true);

            //Timer++;
            Deathtrue = false;


            this.gameObject.transform.position = gm.lastCheckPointPos;
            //Time.timeScale = 0f;
            
            StartCoroutine(RespawnPause());

            //Time.timeScale = 1f;

            Camera.main.gameObject.transform.position = new Vector3(/*gm.lastCheckPointPos.x*/ Camera.main.gameObject.transform.position.x, gm.lastCheckPointPos.y, -10f);

            animator.SetTrigger("Death");

            //transform.position = gm.lastCheckPointPos;
            //cf.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, -10f);

            //currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            //PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator RespawnPause()
    {
        yield return new WaitForSeconds(5f);
    }
}
