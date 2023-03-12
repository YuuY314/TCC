using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;

    public float frogSpeed;

    public Transform rightCollision;
    public Transform leftCollision;
    public Transform headPoint;

    private bool frogIsColliding;

    public LayerMask myLayer;

    public BoxCollider2D myBoxCollider2D;
    public CircleCollider2D myCircleCollider2D;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        myRigidbody2D.velocity = new Vector2(frogSpeed, myRigidbody2D.velocity.y);
        frogIsColliding = Physics2D.Linecast(rightCollision.position, leftCollision.position, myLayer);    
        if(frogIsColliding){
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            frogSpeed = -frogSpeed;
        }
    }

    bool playerIsDestroyed = false;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if(height > 0 && !playerIsDestroyed){
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                frogSpeed = 0;
                myAnimator.SetTrigger("Die");
                myBoxCollider2D.enabled = false;
                myCircleCollider2D.enabled = false;
                myRigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            } else {
                playerIsDestroyed = true;
                GameLogicManager.instance.GameOver();
                Destroy(collision.gameObject);
            }
        }
    }
}
