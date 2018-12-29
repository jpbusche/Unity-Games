using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject blocks;
    public Ball ball;
    public Paddle paddle;
    public Button nextButton;
    public Text messageText;

    void Start() {
        messageText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        int numberOfBlocks = blocks.transform.childCount;
        if(numberOfBlocks <= 0) {
            Destroy(ball.gameObject);
            Destroy(paddle.gameObject);
            messageText.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }
}
