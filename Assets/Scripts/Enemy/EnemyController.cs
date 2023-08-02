using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public int  maxHealth = 100;
    protected int currentHealth;
    private Animator _animator;
    private SpriteRenderer _chomperSprite;


    public float moveSpeed = 2f;
    public bool isFacingRight = true;
    public float patrolDistance = 5f; // Distance the enemy patrols
    public float playerRange = 5f;    // Distance to detect the player

  //  protected Vector3 initialPosition; // Initial position of the enemy for patrolling
    protected Rigidbody2D rb;
    protected Animator animator;

    protected delegate void MoveDelegate();
    protected MoveDelegate moveFunction; // Delegate for movement behavior


    public float patrolRange = 5f;

    public Vector3 originalPosition;
    public Vector3 targetPosition;

    public float delay = 1.0f;
    [SerializeField]
    private AudioClip hurt;


    public virtual void Start()
    {
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        // getting the SpriteRender
        _chomperSprite = GetComponent<SpriteRenderer>();


        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        targetPosition = originalPosition;
        // Set the default movement function to patrol
        moveFunction = Patrol;


       

    }
    // Update is called once per frame
   // public abstract void Update();

    protected virtual void Update()
    {
        // Implement common enemy behavior here.
        // For this example, we'll use a simple horizontal movement.

        /* float horizontalInput = isFacingRight ? 1f : -1f;
         rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);*/

        // Update the animator parameters to control animations
        // _animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        /* if (IsPlayerInRange())
         {
             // Switch to chase behavior if the player is in range
             moveFunction = ChasePlayer;
         }
         else
         {
             // Otherwise, continue patrolling
             moveFunction = Patrol;
         }*/
        moveFunction = Patrol;
        // Call the currently assigned movement function (patrol or chase)
        moveFunction();

        // Update the animator parameters to control animations
       // animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public virtual void TakeDamage(int damage)
    {
       
        currentHealth -= damage;
       // _animator.SetBool("isHurt", true);
        AudioManager.Instance.meleehurt(hurt);
        _animator.SetTrigger("Hurt");
       
        if (currentHealth <= 0)
        {
            Die();
        }

        
    }

    public virtual void Attack()
    {
        Debug.Log("Parent Enemy Attack!");
    }

    protected virtual void Die()
    {
        //Die enemy
        Debug.Log("Chomper Enemy Died");
       _animator.SetBool("isDead", true);

        //Disable enemy
       // GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        // Enemy death logic, like playing death animation, dropping items, etc.

        Destroy(gameObject,delay);
}

   /* protected virtual bool IsPlayerInRange()
    {
        // Implement player detection logic here.
        // You can use Vector3.Distance to check if the player is within the playerRange distance.
        return false; // Replace this with the actual player detection logic.
    }*/

  /*  protected virtual void ChasePlayer()
    {
        // Implement behavior to chase the player.
        // This method will be overridden in the derived enemy classes.
    }*/
    protected virtual void Patrol()
    {
        // Implement behavior for patrolling back and forth.
        // This method will be overridden in the derived enemy classes.
    }

    public void Flip()
    {
        // Flip the enemy's sprite and movement direction
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        
    }

}
