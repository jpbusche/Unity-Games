using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        int totalScore = 0;
        PlayerPrefs.SetInt("Player Score", totalScore);
    }
}
