using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour {

    [Header("UI")]
    public Text scoreText;
    public Text score1Text;
    public Text score2Text;
    public Text resultText;

	// Use this for initialization
	void Start () {
		int score1 = PlayerPrefs.GetInt("score1");
        int score2 = PlayerPrefs.GetInt("score2");
        int score3 = PlayerPrefs.GetInt("score3");

        scoreText.text = string.Format(scoreText.text, score1);
        score1Text.text = string.Format(score1Text.text, score2);
        score2Text.text = string.Format(score2Text.text, score3);
        resultText.text = string.Format(resultText.text, score1 + score2 + score3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnContinue() {
        SceneManager.LoadScene("Menu");
    }
}
