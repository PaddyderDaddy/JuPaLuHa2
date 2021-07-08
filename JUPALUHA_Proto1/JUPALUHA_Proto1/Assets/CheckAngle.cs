using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAngle : MonoBehaviour
{
   // [SerializeField] GameObject collisionPoint;
    //[SerializeField] GameObject dirPointObj;
    [SerializeField] LayerMask layermask;
    [SerializeField] float Raydist;
    [SerializeField] float Force;

    public Rigidbody2D Rbsoundmill;
    public Drumzone drumscript; //Ventopen
    public bool Raycastsoundhit1 = false;
    public bool Raycastsoundhit2 = false;

    // public Instruments instrumentscript; //InstruAktiv
    private void Update()
    {
        if (drumscript.isOpen == true )
        {
            ShootRaycast();

        }
    }

    void ShootRaycast()
    {

        RaycastHit2D hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * Raydist, Color.red);
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Raydist, layermask);

        if (hit)
        {

            if (hit.collider.tag == "SoundmillA")
            {
                Raycastsoundhit1 = true;
                Raycastsoundhit2 = false;

            }
            if (hit.collider.tag == "SoundmillB")
            {
                Raycastsoundhit2 = true;
                Raycastsoundhit1 = false;

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

                //isSoundTouching = true;
                //currentSoundmill = this;
            }
            else
            {
                //clockwise
                hit.rigidbody.angularVelocity = -Force;

                //isSoundTouching = true;
                //currentSoundmill = this;
            }
            
        }
        else
        {
            Raycastsoundhit1 = false;
            Raycastsoundhit2 = false;
        }
    }
}
