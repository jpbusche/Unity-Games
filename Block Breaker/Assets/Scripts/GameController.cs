using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject blocks;  
    public Button nextButton;
    public Text messageText;

    Ball ball;
    Paddle paddle;

    void Start() {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        messageText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        int numberOfBlocks = blocks.transform.childCount;
        if(numberOfBlocks <= 0) {
            if(ball != null) Destroy(ball.gameObject);
            if(paddle != null)Destroy(paddle.gameObject);
            messageText.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }
}
