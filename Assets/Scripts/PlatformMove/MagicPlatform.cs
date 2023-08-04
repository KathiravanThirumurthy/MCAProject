using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPlatform : MonoBehaviour
{

    public Vector3 startPosition; // The starting position of the platform
    public Vector3 endPosition;   // The ending position of the platform
    public float speed = 2f;      // The movement speed of the platform

    private bool movingToEnd = true;

    private void Start()
    {
        // Set the initial position of the platform
        transform.position = startPosition;
    }

    private void Update()
    {
        // Move the platform towards the destination
        float step = speed * Time.deltaTime;
        if (movingToEnd)
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        else
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

        // Check if the platform has reached the destination
        if (transform.position == endPosition)
            movingToEnd = false;
        else if (transform.position == startPosition)
            movingToEnd = true;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Platform touched");
            col.transform.parent = this.transform;
            //  target.transform.parent = null;
        }
    }
    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            Debug.Log("Platfor on exit");

            target.transform.parent = null;
        }
    }
}
