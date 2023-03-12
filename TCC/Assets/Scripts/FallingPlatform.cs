using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float remainingTimeToFall;

    private TargetJoint2D myTargetJoint2D;
    private BoxCollider2D myBoxCollider2D;

    void Start()
    {
        myTargetJoint2D = GetComponent<TargetJoint2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Invoke("Falling", remainingTimeToFall);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer == 9){
            Destroy(gameObject);
        }
    }

    void Falling(){
        myTargetJoint2D.enabled = false;
        myBoxCollider2D.isTrigger = true;
    }
}
