using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShooterGameController : MonoBehaviour {

    [Header("Player")]
    public PlayerShooter player;
    [Header("Zombie")]
    public GameObject zombiePrefab;
    public float spawnPositionX = 10f;
    public float spawnPositionY = -3f;
    [Header("UI")]
    public Text scoreText;
    public Text messageText;
    public Button continueButton;

    private int score;
    private float spawnTimer;
    private float maxSpawnDuration = 2f;
    private float minSpawnDuration = 0.5f;
    private float maxSpeedMultiplier = 3f;
    private float minSpeedMultiplier = 1f;
    private float gameTimer;
    private float gameDuration = 60f;

    // Use this for initialization
    void Start () {
        spawnTimer = maxSpawnDuration;
        messageText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        player.OnPlayerKilled += OnPlayerKilled;
    }
	
	// Update is called once per frame
	void Update () {
        gameTimer += Time.deltaTime;
        spawnTimer -= Time.deltaTime;
        float difficulty = Mathf.Min(gameTimer / gameDuration, 1f);
        if (spawnTimer <= 0) {
            spawnTimer = maxSpawnDuration - (maxSpawnDuration - minSpawnDuration) * difficulty;
            GameObject zombieInstance = Instantiate(zombiePrefab, transform);
            zombieInstance.transform.position = new Vector3(spawnPositionX * (Random.value < 0.5f ? 1 : -1), spawnPositionY, 0);
            zombieInstance.GetComponent<Zombie>().speed *= minSpeedMultiplier + (maxSpeedMultiplier - minSpeedMultiplier) * difficulty;
            zombieInstance.GetComponent<Zombie>().OnZombieKilled += OnZombieKilled;
        }
    }

    void OnPlayerKilled() {
        scoreText.gameObject.SetActive(false);
        messageText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        messageText.text = string.Format(messageText.text, score);
        Time.timeScale = 0;
    }

    void OnZombieKilled() {
        score += 10;
        scoreText.text = "Placar: " + score;
    }

    public void OnContinue() {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("score2", score);
        SceneManager.LoadScene("Cine3");
    }
}
