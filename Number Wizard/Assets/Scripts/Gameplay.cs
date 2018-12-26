using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour {


    public int max;
    public int min;
    public Text guessText;
    int guess;

	// Use this for initialization
	void Start () {
        CalculateGuess();
    }

    void CalculateGuess() {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

    public void OnPressHigher() {
        min = guess + 1;
        CalculateGuess();
    }

    public void OnPressLower() {
        max = guess - 1;
        CalculateGuess();
    }
}
