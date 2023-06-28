using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This abstract class is created for common behaviour for enemy
/// and using inheritance the Enemy base class is derived for various enemies
/// </summary>
public abstract class Enemy : MonoBehaviour
{

    // speed for
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected Transform pointA, pointB;
    // Start is called before the first frame update

    // Update is called once per frame
    /* public virtual void Attack()
     {
         Debug.Log("BaseAttack Called");
     }*/
    public abstract void Update();
}
