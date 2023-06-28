using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranimation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        //Getting Animator component from Inspector panel
        anim = GetComponent<Animator>();
    }
    public void movement(float move)
    {
        // making the animation to play for movement i.e idle to walk and Run
        anim.SetFloat("speed", Mathf.Abs(move));
    }
    public void flipPlayer(float direction)
    {
        // getting the localScale of the Player
        Vector2 scale = transform.localScale;
        // when the speed is negative multiplyig the scale value with (-ve values) to flip the scale and  vice versa
        if (direction < 0) scale.x = -1.0f * Mathf.Abs(scale.x);
        else if (direction > 0) scale.x = Mathf.Abs(scale.x);
        //setting scale to the localScale of the Player
        transform.localScale = scale;
    }
    public void jumping(bool jumping)
    {
        // checking for the jumping animation with SetBool method in the Animator panel
        anim.SetBool("jump", jumping);
    }
    public void playerDead(bool dead)
    {
        anim.SetBool("isDead", dead);
    }
}
