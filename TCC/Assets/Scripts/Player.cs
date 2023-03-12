using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpForce;

    public bool playerIsJumping;
    public bool playerIsDoubleJumping;

    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;

    bool playerIsFloating;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        // transform.position += movement * Time.deltaTime * playerSpeed;
        // jeito muito básico

        float movement = Input.GetAxis("Horizontal");
        myRigidbody2D.velocity = new Vector2(movement * playerSpeed, myRigidbody2D.velocity.y);

        if(movement > 0){
            myAnimator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if(movement < 0){
            myAnimator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else {
            myAnimator.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !playerIsFloating){
            if(!playerIsJumping){
                myRigidbody2D.AddForce(new Vector2(0, playerJumpForce), ForceMode2D.Impulse);
                playerIsDoubleJumping = true;
                myAnimator.SetBool("Jump", true);
            } else {
                if(playerIsDoubleJumping){
                    myRigidbody2D.AddForce(new Vector2(0, playerJumpForce), ForceMode2D.Impulse);
                    playerIsDoubleJumping = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8){
            playerIsJumping = false;
            myAnimator.SetBool("Jump", false);
        }
        
        if(collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Saw"){
            GameLogicManager.instance.GameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "Platform" && Input.GetKey(KeyCode.S)){
            collision.gameObject.layer = 12;
            collision.gameObject.GetComponent<TilemapCollider2D>().isTrigger = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8){
            playerIsJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.layer == 11){
            playerIsFloating = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.layer == 11){
            playerIsFloating = false;
        }

        if(collider.gameObject.layer == 12){
            float timer = 0;
            while(timer < 1){
                timer += 1 * Time.deltaTime;
            }

            collider.gameObject.GetComponent<TilemapCollider2D>().isTrigger = false;
            collider.gameObject.layer = 8;
        }
    }
}
