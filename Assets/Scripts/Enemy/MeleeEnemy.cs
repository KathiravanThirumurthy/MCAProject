using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{

    public Transform player;
    public float meleeRange = 2f;


   /* private Vector3 originalPosition;
    private Vector3 targetPosition;*/


    public override void Start()
    {
        base.Start();
        //initialPosition = transform.position;
      /*  originalPosition = transform.position;
        targetPosition = originalPosition;*/

    }
    
    protected override void Update()
    {
        base.Update();

    }
   /* protected override bool IsPlayerInRange()
    {
        // Check the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Return true if the player is within the playerRange distance
        return distanceToPlayer <= playerRange;
    }*/

   /* protected override void ChasePlayer()
    {
        // Implement behavior to chase the player here.
        // For example, move towards the player's position using rb.velocity.
        // You can also implement attacking behavior when the player is within attack range.
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;
    }
   */
    protected override void Patrol()
    {

      // Check if the enemy is at the target position
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            // Set the new target position based on the current direction
            targetPosition = isFacingRight ?originalPosition - Vector3.right * patrolRange: originalPosition + Vector3.right * patrolRange;

            // Flip the enemy's direction
            isFacingRight = !isFacingRight;
        }

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Flip the enemy's sprite based on the direction

        if ((isFacingRight && transform.localScale.x < 0) || (!isFacingRight && transform.localScale.x > 0))
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }


    }
    
    public override void TakeDamage(int attackDamage)
    {
        
        base.TakeDamage(attackDamage);

    }
    public override void Attack()
    {
        // Call the base (parent) class's Attack method
        base.Attack();

        // Add additional behavior for the MeleeEnemy
        Debug.Log("Melee Enemy Attack!");
    }
}
