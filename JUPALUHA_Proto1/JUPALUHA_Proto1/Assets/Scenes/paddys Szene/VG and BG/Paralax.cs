using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [Range(-1, 1)] public float Scrollspeed; //jetzt kann ich nur zwischen -1 und 1 ändern :D
    Transform camTransform;
    float spriteWidth;
    float LastCameraY;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        spriteWidth = GetComponent<SpriteRenderer>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = camTransform.position.y - LastCameraY;
        transform.position += new Vector3(0, delta * Scrollspeed, 0);


        LastCameraY = camTransform.position.y;
        //jump 
        /*
        if(transform.position.x < camTransform.position.x - spriteWidth)
        {
            transform.position += new Vector3(spriteWidth * 2, 0, 0);
        }

        if(transform) */
    }
}
