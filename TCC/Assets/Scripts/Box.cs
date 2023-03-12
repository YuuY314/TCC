using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float boxThrowForce;
    public bool boxIsThrowingUp;
    public int boxHealth;

    public Animator myAnimator;
    public GameObject effect;
    public SpriteRenderer parentSpriteRenderer;
    public BoxCollider2D parentBoxCollider2D;

    void Update()
    {
        if(boxHealth <= 0){
            parentSpriteRenderer.enabled = false;
            parentBoxCollider2D.enabled = false;
            effect.SetActive(true);
            Destroy(transform.parent.gameObject, 0.25f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(boxIsThrowingUp){
            myAnimator.SetTrigger("Hit");
            boxHealth--;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, boxThrowForce), ForceMode2D.Impulse);
        } else {
            myAnimator.SetTrigger("Hit");
            boxHealth--;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -boxThrowForce), ForceMode2D.Impulse);
        }
    }
}
