﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    public Sprite[] overlays;
    public Image overlay;
    public Text scoreText, timeText;
    public float time = 30f;

    Player player;
    
    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<Player>();
        overlay.gameObject.SetActive(false);
        scoreText.text = "Score: " + player.gemCollected.ToString();
        timeText.text = "Time: " + time.ToString();
    }

    // Update is called once per frame
    void Update() {
        time -= Time.deltaTime;
        int timeInt = (int)time;
        scoreText.text = "Score: " + player.gemCollected.ToString();
        timeText.text = "Time: " + timeInt.ToString();
        if(player.won) {
            overlay.sprite = overlays[0];
            overlay.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Congratulations");
        } else if(player.isDead) {
            overlay.sprite = overlays[1];
            overlay.gameObject.SetActive(true);
            Scene scene = SceneManager.GetActiveScene();
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.name);
        } else if(time <= 0) {
            overlay.sprite = overlays[2];
            overlay.gameObject.SetActive(true);
            timeText.text = "Time: 0";
            Scene scene = SceneManager.GetActiveScene();
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.name);
        }
    }
}
