using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public GameObject pipe;
    public float rotZ;

    bool isOnPendulum;

    [SerializeField] Transform rotCenter;

    private void Update()
    {
        //transform.position = new Vector2(rotCenter.position.x + (5 * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.z)),
        //                                 rotCenter.position.y + (5 * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.z)));

        transform.eulerAngles += new Vector3(0, 0, 20);
    }


    /*
     * case InteractionType.Examine:
                if (KeyPressed <= 0)
                {
                    pipe.transform.localEulerAngles = new Vector3(0, 0, rotZ);
                }
                else
                {
                    pipe.transform.localEulerAngles = new Vector3(0, 0, -rotZ);
                }
                break;
    */
}
