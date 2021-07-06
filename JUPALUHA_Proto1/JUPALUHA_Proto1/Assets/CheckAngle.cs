using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAngle : MonoBehaviour
{
    [SerializeField] GameObject collisionPoint;
    [SerializeField] GameObject dirPointObj;
    [SerializeField] LayerMask layermask;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ShootRaycast();
    }

    void ShootRaycast()
    {
        RaycastHit2D hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 5f, Color.red);
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 5f, layermask);

        if (hit)
        {
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
                hit.rigidbody.angularVelocity = 100;

                //isSoundTouching = true;
                //currentSoundmill = this;
            }
            else
            {
                //clockwise
                hit.rigidbody.angularVelocity = -100;

                //isSoundTouching = true;
                //currentSoundmill = this;
            }
        }
    }
}
