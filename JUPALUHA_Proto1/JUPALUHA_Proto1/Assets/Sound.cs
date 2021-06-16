using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    private Rigidbody2D rb;
    SpriteRenderer Renderer;

    [Header("Sound Parameters")]
    public float speed = 10f;
    public float DestroyTime;
    public float collisionRadius;
    public GameObject spawnStartPoint;

    public enum PipeDirection {Left, Right, Up, Down}
    public PipeDirection type;

    [Header("Boolins")]
    public bool pipeUp;
    public bool onStart;
    public bool TouchingObject = false;

    public enum SoundOutput {SoundOutput, SoundOutput1, SoundOutput2, SoundOutput3, SoundOutput4, SoundOutput5, SoundOutput6, SoundOutput7 }
    public SoundOutput number;

    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, -1) * speed;
        //rb.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        TouchingObject = Physics2D.OverlapCircle(rb.transform.position, collisionRadius, LayerMask.GetMask("Soundmillrotor"));

    }

    private void FixedUpdate()
    {

        switch (number)
        {
            case SoundOutput.SoundOutput:
                if (GameObject.Find("RotationPoint").transform.rotation.eulerAngles.z == 55)
                {
                    pipeUp = true;
                }
                if (GameObject.Find("RotationPoint").transform.rotation.eulerAngles.z == -55)
                {
                    pipeUp = false;
                }

                if (GameObject.Find("SoundOutput").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }
                break;
            case SoundOutput.SoundOutput1:
                if (GameObject.Find("RotationPoint1").transform.localEulerAngles.z == 55)
                {
                    pipeUp = true;

                }
                if (GameObject.Find("RotationPoint1").transform.localEulerAngles.z == -55)
                {
                    pipeUp = false;

                }

                if (GameObject.Find("SoundOutput1").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }

                break;
            case SoundOutput.SoundOutput2:
                if (GameObject.Find("RotationPoint2").transform.rotation.eulerAngles.z == 55)
                {
                    pipeUp = true;
                }
                if (GameObject.Find("RotationPoint2").transform.rotation.eulerAngles.z == -55)
                {
                    pipeUp = false;
                }

                if (GameObject.Find("SoundOutput2").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }
                break;
            case SoundOutput.SoundOutput3:
                if (GameObject.Find("RotationPoint3").transform.rotation.eulerAngles.z == 55)
                {
                    pipeUp = true;
                }
                if (GameObject.Find("RotationPoint3").transform.rotation.eulerAngles.z == -55)
                {
                    pipeUp = false;
                }

                if (GameObject.Find("SoundOutput3").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }
                break;
            case SoundOutput.SoundOutput4:
                if (GameObject.Find("RotationPoint4").transform.rotation.eulerAngles.z == -55)
                {
                    pipeUp = true;
                    Debug.Log("Up");
                }
                if (GameObject.Find("RotationPoint4").transform.rotation.eulerAngles.z == 55)
                {
                    pipeUp = false;
                    Debug.Log("Down");
                }

                if (GameObject.Find("SoundOutput4").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }
                break;
            case SoundOutput.SoundOutput5:
                if (GameObject.Find("RotationPoint5").transform.rotation.eulerAngles.z == 55)
                {
                    pipeUp = true;
                }
                if (GameObject.Find("RotationPoint5").transform.rotation.eulerAngles.z == -55)
                {
                    pipeUp = false;
                }

                if (GameObject.Find("SoundOutput5").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }
                break;
            case SoundOutput.SoundOutput6:
                pipeUp = true;

                if (GameObject.Find("SoundOutput6").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }
                break;
            case SoundOutput.SoundOutput7:
                if (GameObject.Find("RotationPoint7").transform.rotation.eulerAngles.z == 55)
                {
                    pipeUp = true;
                }
                if (GameObject.Find("RotationPoint7").transform.rotation.eulerAngles.z == -55)
                {
                    pipeUp = false;
                }

                if (GameObject.Find("SoundOutput7").transform.position == this.gameObject.transform.position)
                {
                    onStart = true;

                }
                else
                {
                    onStart = false;
                }
                break;
            default:
                break;
        }
        Round();

    }

    void Update()
    {

        //DESTROY SOUND
        if (TouchingObject == true)
        {
            Destroy(this.gameObject, DestroyTime);
        }
        else
        {
            Destroy(this.gameObject, 4f);
        }

    }

    public void Round()
    {
        if (onStart == true)
        {
            switch (type)
            {
                case PipeDirection.Left:
                    if (pipeUp == true)
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(-1, 1) * speed;
                    }
                    else
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(-1, -1) * speed;
                    }
                    break;
                case PipeDirection.Right:
                    if (pipeUp == true)
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(1, 1) * speed;
                    }
                    else
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(1, -1) * speed;
                    }
                    break;
                case PipeDirection.Up:
                    if (pipeUp == true)
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(-1, 1) * speed;
                    }
                    else
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(1, 1) * speed;
                    }
                    break;
                case PipeDirection.Down:
                    if (pipeUp == true)
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(-1, -1) * speed;
                        Debug.Log("UP");
                    }
                    else
                    {
                        rb = GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector2(1, -1) * speed;
                        Debug.Log("DOWN");
                    }
                    break;

                default:
                    break;
            }
        }
    }



}
