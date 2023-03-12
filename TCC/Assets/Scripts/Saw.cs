using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float sawSpeed;
    public float sawMoveTime;
    private bool rightDirection = true;
    private float timer;

    void Update()
    {
        if(rightDirection){
            transform.Translate(Vector2.right * sawSpeed * Time.deltaTime);
        } else {
            transform.Translate(Vector2.left * sawSpeed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if(timer >= sawMoveTime){
            rightDirection = !rightDirection;
            timer = 0;
        }
    }
}
