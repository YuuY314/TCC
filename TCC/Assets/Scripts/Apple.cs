using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private CircleCollider2D myCircleCollider2D;
    public GameObject collected;

    public int score;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            Debug.Log(score);
            mySpriteRenderer.enabled = false;
            myCircleCollider2D.enabled = false;
            collected.SetActive(true);
            
            GameLogicManager.instance.totalScore += score;
            GameLogicManager.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
