using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding : MonoBehaviour
{

    [SerializeField]
    private float m_FallSpeed = 0f;

    private Rigidbody2D Rigidbody;

    public bool IsGliding = false;

    private float glideTimer;

    public PausePlayer pausePlayerscript;
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(pausePlayerscript.Deathtrue ==true)
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Mathf.Sign(Rigidbody.velocity.y) * m_FallSpeed);

        if (IsGliding)
            glideTimer += Time.deltaTime;

        if (IsGliding == false)
            glideTimer= 0;

        if (glideTimer >= 2 || Input.GetKeyDown(KeyCode.S))
        {
            IsGliding = false;
        }

        if (IsGliding && Rigidbody.velocity.y < 0f && Mathf.Abs(Rigidbody.velocity.y) > m_FallSpeed)
        { 
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Mathf.Sign(Rigidbody.velocity.y) * m_FallSpeed);
        }

    }

    public void StartGliding()
    {
        IsGliding = true;
    }

    public void StopGliding()
    {
        IsGliding = false;
    }
}

