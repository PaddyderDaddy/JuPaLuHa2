using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    public Vector2 followOffset;
    private Vector2 threshold;
    public float speed = 3f;
    private Rigidbody2D followObjectRigidbody;

    private GameManager gm;


    void Start()
    {
        threshold = calculateThreshold();
        followObjectRigidbody = followObject.GetComponent<Rigidbody2D>();

        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = new Vector3(/*gm.lastCheckPointPos.x*/transform.position.x, gm.lastCheckPointPos.y, -10);
    }

    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
       //float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
       // if (Mathf.Abs(xDifference) >= threshold.x)
       //     newPosition.x = follow.x;
        if (Mathf.Abs(yDifference) >= threshold.y)
            newPosition.y = follow.y;

        float moveSpeed = followObjectRigidbody.velocity.magnitude > speed ? followObjectRigidbody.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
       // t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
