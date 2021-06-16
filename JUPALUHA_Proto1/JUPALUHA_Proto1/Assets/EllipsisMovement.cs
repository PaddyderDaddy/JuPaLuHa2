using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipsisMovement : MonoBehaviour
{
    [SerializeField] float rotationRadius = 10;
    [SerializeField] float tilt = 45f;

    public Transform rotationCenter;
    [SerializeField] float angle;
    float speed;
    bool InMotion = true;

    Collider2D CableCarCollider;
    SpriteRenderer CableCarRenderer;
    float CableCarVanishTimer;
    bool VanishTimerActive;

    public CharControllerPhysics ControlScript;
    public GameManager GameManagerScript;

    private void Start()
    {
        CableCarCollider = GetComponent<Collider2D>();
        CableCarRenderer = GetComponent<SpriteRenderer>();
        CableCarVanishTimer = 0;
    }

    void Update()
    {
        ChangeVelocity();

        StopMotion();

        if (InMotion)
        {
            transform.position = new Vector2(rotationCenter.position.x + (rotationRadius * MCos(angle) * MCos(tilt)) - ((rotationRadius / 2) * MSin(angle) * MSin(tilt)),
                                             rotationCenter.position.y + (rotationRadius * MCos(angle) * MSin(tilt)) + ((rotationRadius / 2) * MSin(angle) * MCos(tilt)));
            angle += speed * Time.deltaTime;
            if (angle >= 360)
                angle = 0;
        }

        //disable collision with cablecars when on soundmill
        if (ControlScript.IsOnSoundMill == true)
            CableCarCollider.enabled = false;
        else
            CableCarCollider.enabled = true;

        //making cablecars disappear after collision
        if (VanishTimerActive == true && ControlScript.IsOnSoundMill == false)
        {
            CableCarVanishTimer += Time.deltaTime;
            if (CableCarVanishTimer >= 3 && CableCarVanishTimer < 6)
            {
                CableCarRenderer.enabled = false;
                CableCarCollider.enabled = false;
            }
            else if (CableCarVanishTimer >= 6)
            {
                CableCarRenderer.enabled = true;
                CableCarCollider.enabled = true;
                VanishTimerActive = false;
                CableCarVanishTimer = 0;
            }
        }
        else if (VanishTimerActive == false && ControlScript.IsOnSoundMill == false)
        {
            VanishTimerActive = false;
            CableCarVanishTimer = 0;
            CableCarRenderer.enabled = true;
            CableCarCollider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
            VanishTimerActive = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
            ControlScript.Grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
            ControlScript.Grounded = false;
        }
    }

    void StopMotion()
    {
        if (Input.GetKeyDown(KeyCode.P))
            InMotion = !InMotion;
    }

    float MCos(float value)
    {
        return Mathf.Cos(Mathf.Deg2Rad * value);
    }

    float MSin(float value)
    {
        return Mathf.Sin(Mathf.Deg2Rad * value);
    }

    void ChangeVelocity()
    {
        if (GameManager.instance.ActiveSoundmill != null)
        {
            speed = GameManager.instance.ActiveSoundmill.rb.angularVelocity * 0.5f;
        }
    }
}
