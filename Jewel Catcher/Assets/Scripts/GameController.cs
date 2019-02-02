using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Sprite[] overlays;
    public Image overlay;
    public Text scoreText, timeText;
    public float time = 30f;

    Player player;
    Scene scene;
    AudioSource myAudio;

    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<Player>();
        myAudio = GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene();
        overlay.gameObject.SetActive(false);
        scoreText.text = "Score: " + player.gemCollected.ToString();
        timeText.text = "Time: " + time.ToString();
    }

    // Update is called once per frame
    void Update() {
        if(player.won) {
            myAudio.mute = true;
            overlay.sprite = overlays[0];
            overlay.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.buildIndex + 1);
        } else if(player.isDead) {
            myAudio.mute = true;
            overlay.sprite = overlays[1];
            overlay.gameObject.SetActive(true);
            timeText.text = "Time: 0";
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.buildIndex);
        } else if(time <= 0) {
            myAudio.mute = true;
            overlay.sprite = overlays[2];
            overlay.gameObject.SetActive(true);
            timeText.text = "Time: 0";
            if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene.buildIndex);
        } else {
            time -= Time.deltaTime;
            int timeInt = (int)time;
            scoreText.text = "Score: " + player.gemCollected.ToString();
            timeText.text = "Time: " + timeInt.ToString();
        }
    }
}
