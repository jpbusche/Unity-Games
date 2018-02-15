using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunnerGameController : MonoBehaviour {

    public float targetDistance = 50f;
    [Header("Obstacle")]
    public GameObject[] obstaclePrefabs;
    public PlayerRunner player;
    public float spawnDistance;
    public float spawnOffset;
    [Header("UI")]
    public Text timeText;
    public Text distanceText;
    public Text messageText;
    public Button continueButton;

    private float spawnPointer;
    private float gameTimer;
    private bool gameOver;

    // Use this for initialization
    void Start () {
        messageText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        spawnPointer = player.transform.position.x + spawnOffset;
    }
	
	// Update is called once per frame
	void Update () {
        if(gameOver == false) gameTimer += Time.deltaTime;
		if(spawnPointer < player.transform.position.x + spawnOffset) {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            GameObject obstacleInstance = Instantiate(obstaclePrefab, transform);
            obstacleInstance.transform.position = new Vector3(spawnPointer, obstacleInstance.transform.position.y, obstacleInstance.transform.position.z);
            spawnPointer += spawnDistance;
        }
        float remaingDistance =  Mathf.Max(targetDistance - player.transform.position.x, 0);
        if(remaingDistance <= 0) {
            if(gameOver == false) {
                gameOver = true;
                EndGame();
            }
        }
        timeText.text = "Tempo: " + (int)gameTimer + " s";
        distanceText.text = "Distância: " + (int)remaingDistance + " m";
	}

    void EndGame() {
        Time.timeScale = 0;
        timeText.gameObject.SetActive(false);
        distanceText.gameObject.SetActive(false);
        messageText.gameObject.SetActive(true);
        messageText.text = string.Format(messageText.text, (int)gameTimer);
        continueButton.gameObject.SetActive(true);
    }


    public void OnContinue() {
        Time.timeScale = 1;
        int score = (int)(30000f / gameTimer);
        PlayerPrefs.SetInt("score3", score);
        SceneManager.LoadScene("Result");
    }
}
