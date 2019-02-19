using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {
        int totalCoins = 0;
        PlayerPrefs.SetInt("Player Coins", totalCoins);
    }

}
