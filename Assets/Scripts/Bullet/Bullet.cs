using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		//Debug.Log(hitInfo.name);
		BossHealth enemy = hitInfo.GetComponent<BossHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(20);
			
		}

		/*Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);*/
		Debug.Log("enemy destroyed");
		//gameObject.SetActive(false);
		Destroy(gameObject);
	}
}
