using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public Text coinText;

    // Start is called before the first frame update
    void Start() {
        int totalCoins = PlayerPrefs.GetInt("Player Coins");
        coinText.text = "Coins Collected: " + totalCoins.ToString();
    }

}
