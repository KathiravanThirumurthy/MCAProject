using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform throwPoint; // The point from which the bombs will be thrown
    public float throwForce = 10f;
    public float throwInterval = 2f; // Time between bomb throws

    private Animator animator;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (!isAttacking)
            {
                isAttacking = true;
                animator.SetTrigger("isAttack"); // Trigger the attack animation

                yield return new WaitForSeconds(0.5f); // Adjust this delay to match animation timing

                ThrowBomb();

                yield return new WaitForSeconds(throwInterval);
                isAttacking = false;
            }
            yield return null;
        }
    }

    private void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, Quaternion.identity);
        bombPrefab.SetActive(true);
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();

        // Apply force to the bomb to simulate throwing
        rb.AddForce(-throwPoint.right * throwForce, ForceMode2D.Impulse);
    }
}
