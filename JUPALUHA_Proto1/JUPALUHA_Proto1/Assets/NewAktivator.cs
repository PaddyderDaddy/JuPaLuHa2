using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAktivator : MonoBehaviour
{
    public bool AktivatorAktiv;
    public SoundmillRotation SoundmillScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SoundmillScript.isSoundtouching == false)
            AktivatorAktiv = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AktivatorAktiv = true;
    }
}
