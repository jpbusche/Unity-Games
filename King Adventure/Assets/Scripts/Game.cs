using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public Text endText;

    King king;
    Scene scene;

    // Start is called before the first frame update
    void Start() {
        king = FindObjectOfType<King>();
        scene = SceneManager.GetActiveScene();
        endText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if(king.won) {
            endText.text = "You Won                            Press Space";
            endText.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.buildIndex + 1);
        } else if(king == null) {
            endText.text = "You Died                            Press Space";
            endText.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.buildIndex);
        }
    }
}
