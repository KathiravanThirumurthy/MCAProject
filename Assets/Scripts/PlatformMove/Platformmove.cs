using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformmove : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private float speed;
    // Initializing target pos
    private Vector3 _currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementPlatform();
    }
    private void movementPlatform()
    {
        //flipChomper();
        // checking if th position is in point A
        if (transform.position == pointA.position)
        {
            // setting pointB waypoint position to currentTarget
            _currentTarget = pointB.position;
           
        }
        else if (transform.position == pointB.position)
        {
            // setting pointA waypoint position to currentTarget
            _currentTarget = pointA.position;
            // making the animation to play from idle to walk
           
        }
        // moving the Gameobject from intial point to the destination with a speed
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Platfor touched");
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
