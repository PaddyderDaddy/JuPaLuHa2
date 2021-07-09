using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundmillRotation ActiveSoundmill;
    public Pendulum ActivePendulum;

    public static GameManager instance;
    public Vector2 lastCheckPointPos;

    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("created game manager");
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Debug.Log("deleted game manager");
            Destroy(gameObject);
        }
    }
}

