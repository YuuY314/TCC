using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float trampolineJumpForce;
    
    private Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            myAnimator.SetTrigger("Jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, trampolineJumpForce), ForceMode2D.Impulse);
        }
    }
}
