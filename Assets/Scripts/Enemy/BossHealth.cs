using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
		Debug.Log("Health:" + health);
		/*if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}*/

		if (health <= 0)
		{
			//Die();
			Debug.Log("Health:"+health);
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
