﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle paddle;
    public float velY = 15f;
    public float velX = 0.5f;

    Vector2 distance;
    bool isLauched = false;

    // Start is called before the first frame update
    void Start() {
        distance = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() { 
        if(!isLauched) {
            LockBall();
            LauchBall();
        }
    }

    public void LockBall() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + distance;
    }

    private void LauchBall() {
        if(Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
            isLauched = true;
        }
    }
}
