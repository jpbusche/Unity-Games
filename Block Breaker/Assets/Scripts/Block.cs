using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public Sprite[] blockSprites;
    public GameObject blockSparkles;
    public int lives = 2;

    SpriteRenderer render;

    void Start() {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Ball") {
            if(lives == 0) {
                InstanceSparkles();
                FindObjectOfType<GameController>().DecreaseNumberOfBlock();
                Destroy(gameObject);
            }
            else {
                lives--;
                render.sprite = blockSprites[lives];
            }
        }
    }

    private void InstanceSparkles() {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
