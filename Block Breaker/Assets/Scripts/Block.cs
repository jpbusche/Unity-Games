﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public Sprite[] blockSprites;
    public int lives = 2;

    SpriteRenderer render;

    void Start() {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Ball") {
            if(lives == 0) Destroy(gameObject);
            else {
                lives--;
                render.sprite = blockSprites[lives];
            }
        }
    }

}
