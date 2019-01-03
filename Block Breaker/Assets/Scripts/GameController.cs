using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject blocks;  
    public Button nextButton;
    public Text messageText;
    public Text blocksText;

    Ball ball;
    Paddle paddle;
    int numberOfBlocks;

    void Start() {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        messageText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        numberOfBlocks = blocks.transform.childCount;
        blocksText.text = "Blocks       " + numberOfBlocks.ToString();
    }

    // Update is called once per frame
    void Update() {
        numberOfBlocks = blocks.transform.childCount;
        blocksText.text = "Blocks       " + numberOfBlocks.ToString();
        if(numberOfBlocks <= 0) {
            if(ball != null) Destroy(ball.gameObject);
            if(paddle != null)Destroy(paddle.gameObject);
            messageText.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
            blocksText.gameObject.SetActive(false);
        }
    }
}
