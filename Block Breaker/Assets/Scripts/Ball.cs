using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public Paddle paddle;
    public float velY = 20f;
    public float velX = 0.5f;
    public float randomFactor = 0.2f;
    public float numLifes = 3;

    Vector2 distance;
    bool isLauched;
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start() {
        isLauched = false;
        distance = transform.position - paddle.transform.position;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { 
        if(!isLauched) {
            LockBall();
            LauchBall();
        }
    }

    private void LockBall() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + distance;
    }

    private void LauchBall() {
        if(Input.GetMouseButtonDown(0)) {
            myRigidbody.velocity = new Vector2(velX, velY);
            isLauched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if(isLauched && collision.gameObject.name != "Left Wall" && collision.gameObject.name != "Right Wall" && collision.gameObject.name != "Top Wall" && collision.gameObject.name != "Lose Collider") {
            GetComponent<AudioSource>().Play();
            myRigidbody.velocity += velocityTweak;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Lose Collider") {
            numLifes--;
            if (numLifes == 0) SceneManager.LoadScene("Game Over");
            isLauched = false;
        }
    }
}
