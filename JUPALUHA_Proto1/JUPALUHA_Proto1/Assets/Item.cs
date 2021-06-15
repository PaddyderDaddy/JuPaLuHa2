using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine, Grab, OpenVent }
    public InteractionType type;
    public int KeyPressed = 0;

    [Header("Pipe Rotation")]
    public GameObject pipe;
    public float rotZ;


    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 6;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyPressed++;
        }

        if (KeyPressed >= 2)
            KeyPressed = 0;

    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                FindObjectOfType<Interaction>().PickUpItem(gameObject);
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                if (KeyPressed <= 0)
                {
                    pipe.transform.localEulerAngles = new Vector3(0, 0, rotZ);
                }
                else
                {
                    pipe.transform.localEulerAngles = new Vector3(0, 0, -rotZ);
                }
                break;
            default:
                Debug.Log("NONE");
                break;

        }
    }

}
