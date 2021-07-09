using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAngle : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    [SerializeField] float Raydist;
    [SerializeField] float Force;

    SoundmillRotation currentSoundmill;

    public Rigidbody2D Rbsoundmill;
    public Drumzone drumscript; //Ventopen

    public GameObject visEffect;

    private void Start()
    {
        visEffect.SetActive(false);
    }

    private void Update()
    {
        if (drumscript.isOpen == true )
        {
            ShootRaycast();
            visEffect.SetActive(true);
        }
    }

    void ShootRaycast()
    {

        RaycastHit2D hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * Raydist, Color.red);
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Raydist, layermask);

        if (hit)
        {
            currentSoundmill = hit.transform.gameObject.GetComponent<SoundmillRotation>();

            //if (currentSoundmill != null)
            //    GameManager.instance.ActiveSoundmill = currentSoundmill;

            if (currentSoundmill != null)
            {
                currentSoundmill.isSoundmillFuckingActive = true;
                currentSoundmill.ConnectedSoundmill.isSoundmillFuckingActive = false;
                currentSoundmill.isPoweredByRaycast = true;
                currentSoundmill.ConnectedSoundmill.isPoweredByRaycast = true;
            }

            Vector3 posTangent = Quaternion.Euler(0, 0, 90) * hit.normal;
            Vector3 negTangent = Quaternion.Euler(0, 0, -90) * hit.normal;

            Vector3 direction = transform.TransformDirection(Vector2.right);

            Debug.DrawLine(hit.transform.position, hit.point, Color.cyan); //normal vector
            Debug.DrawLine(hit.point, hit.point + new Vector2(posTangent.x, posTangent.y), Color.green); //posTangent
            Debug.DrawLine(hit.point, hit.point + new Vector2(negTangent.x, negTangent.y), Color.yellow); //negTangent

            float posAngle = Vector3.Angle(direction, posTangent);
            float negAngle = Vector3.Angle(direction, negTangent);

            if (posAngle == negAngle) return;

            if (posAngle < negAngle)
            {
                //anticlockwise            
                hit.rigidbody.angularVelocity = Force;
            }
            else
            {
                //clockwise
                hit.rigidbody.angularVelocity = -Force;
            }

        }
        else
        {
            if (currentSoundmill == null) return;

            currentSoundmill.isPoweredByRaycast = false;
            currentSoundmill.ConnectedSoundmill.isPoweredByRaycast = false;
        }
    }
}
