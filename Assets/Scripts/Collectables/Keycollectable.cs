using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycollectable : MonoBehaviour
{
    // declaring the variable for score
    private int _score;
    // Intializing the playercontroller
    private Playercontroller _playercontroller;
    [SerializeField]
    private GameObject _particles;
    void Awake()
    {
        // for this key collectable score value is assigned as 10
        _score = 10;

    }
    // checking for the Collision of the key gameobject with Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collected");
        // getting the component of the collision object a
        _playercontroller = collision.gameObject.GetComponent<Playercontroller>();
        // checking whether the component is available
        if (_playercontroller != null)
        {
            // on getting the component calling the pickup key method from PlayerController
            _playercontroller.pickUpKey(_score);
            Instantiate(_particles, gameObject.transform.position,Quaternion.identity);
            //after collision destroying the collectable item
            Destroy(this.gameObject);
        }
    }
}
