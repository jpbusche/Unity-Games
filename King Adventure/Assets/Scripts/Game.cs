using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public Text endText;
    public Image lifeBar;
    public Sprite[] sprites;

    King king;
    Scene scene;

    // Start is called before the first frame update
    void Start() {
        king = FindObjectOfType<King>();
        scene = SceneManager.GetActiveScene();
        lifeBar.sprite = sprites[3];
        endText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        lifeBar.sprite = sprites[king.health];
        if(king.won) {
            endText.text = "You Won                            Press Space";
            endText.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.buildIndex + 1);
        } else if(king == null) {
            lifeBar.sprite = sprites[0];
            endText.text = "You Died                            Press Space";
            endText.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.buildIndex);
        }
    }
}
