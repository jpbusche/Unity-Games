using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public Sprite[] blockSprites;
    public int lives = 2;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = blockSprites[0];
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Ball") {
            if(lives == 0) Destroy(gameObject);
            lives--;
             GetComponent<SpriteRenderer>().sprite = blockSprites[lives + 1];
        }
    }

}
