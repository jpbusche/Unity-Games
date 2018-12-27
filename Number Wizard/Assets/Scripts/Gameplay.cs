using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour {


    public int max;
    public int min;
    public int numberGuess;
    public Text guessText;
    int guess;

	// Use this for initialization
	void Start () {
        CalculateGuess();
    }

    void Update() {
        if(numberGuess == 0) {
            SceneManager.LoadScene("Lose");
        }
    }

    void CalculateGuess() {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

    public void OnPressHigher() {
        min = guess + 1;
        CalculateGuess();
        numberGuess -= 1;
    }

    public void OnPressLower() {
        max = guess - 1;
        CalculateGuess();
        numberGuess -= 1;
    }
}
