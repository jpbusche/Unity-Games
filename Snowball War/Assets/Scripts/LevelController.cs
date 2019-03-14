using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public Text winText;
    public Image[] p1Lifes, p2Lifes;
    [SerializeField] GameObject player1, player2;
    [SerializeField] AudioClip soundEffect;
    
    int p1Life, p2Life;
    bool won = false;
    // Start is called before the first frame update
    void Start() {
        p1Life = p1Lifes.Length;
        p2Life = p2Lifes.Length;
    }

    // Update is called once per frame
    void Update() {
        if(p1Life <= 0) {
            Destroy(player1);
            winText.text = "Player 2 Wins";
            won = true;
        } else if(p2Life <= 0) {
            Destroy(player2);
            winText.text = "Player 1 Wins";
            won = true;
        }
        if(won) {
            if(Input.GetKeyDown("joystick button 0")) {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Hurt(int player) {
        if(player == 1) {
            p1Life--;
            AudioSource.PlayClipAtPoint(soundEffect, player1.transform.position);
            for(int i = 0; i < p1Lifes.Length; ++i) {
                if(p1Life > i) p1Lifes[i].gameObject.SetActive(true);
                else p1Lifes[i].gameObject.SetActive(false);
            }
        }  else if(player == 2) {
            p2Life--;
            AudioSource.PlayClipAtPoint(soundEffect, player2.transform.position);
            for(int i = 0; i < p2Lifes.Length; ++i) {
                if(p2Life > i) p2Lifes[i].gameObject.SetActive(true);
                else p2Lifes[i].gameObject.SetActive(false);
            }
        }
    } 
}
