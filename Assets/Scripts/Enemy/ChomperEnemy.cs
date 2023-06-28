using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enemy Chomper is created and checking for player collision with Enemy and updating player lives
/// </summary>
public class ChomperEnemy : Enemy
{
    // Initializing target pos
    private Vector3 _currentTarget;

    private Animator _animator;

    private SpriteRenderer _chomperSprite;
    // Intializing the playercontroller
    private Playercontroller _playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        // getting the Animator component
        _animator = GetComponent<Animator>();
        // getting the SpriteRender
        _chomperSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Debug.Log("ChomperEnemey updated......");
        // Getting the state of the Animator and checking for Idle state
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("ChomperIdle"))
        {
            // do nothing
            return;
        }
        // Creating the Patrol AI for Enemy
        movementEnemy();
    }
    private void movementEnemy()
    {
        flipChomper();
        // checking if th position is in point A
        if (transform.position == pointA.position)
        {
            // setting pointB waypoint position to currentTarget
            _currentTarget = pointB.position;
            // making the animation to play from idle to walk
            _animator.SetTrigger("chomperidle");
        }
        else if (transform.position == pointB.position)
        {
            // setting pointA waypoint position to currentTarget
            _currentTarget = pointA.position;
            // making the animation to play from idle to walk
            _animator.SetTrigger("chomperidle");
        }
        // moving the Gameobject from intial point to the destination with a speed
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }
    private void flipChomper()
    {
        //if the enemy is in pointA waypoints
        if (_currentTarget == pointA.position)
        {
            //flipping the sprite and making it true
            _chomperSprite.flipX = true;
        }
        else
        {
            //flipping the sprite and making it false
            _chomperSprite.flipX = false;
        }
    }

    // checking for the Collision of the key gameobject with Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide");
        // getting the component of the collision object a
        _playercontroller = collision.gameObject.GetComponent<Playercontroller>();
        // checking whether the component is available
        if (_playercontroller != null)
        {
            // on getting the component calling the pickup key method from PlayerController
            _playercontroller.playerDead(true);

        }
    }
}
