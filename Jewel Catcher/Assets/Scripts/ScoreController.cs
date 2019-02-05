using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text gemText;

    int totalScore;

    // Start is called before the first frame update
    void Start() {
        totalScore = PlayerPrefs.GetInt("Player Score");
        gemText.text = "Gems Collected: " + totalScore.ToString();
    }
}
