using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceGameController : MonoBehaviour {

    [Header("Player")]
    public PlayerShip player;
    public GameObject explosionPrefab;
    public GameObject damagePrefab;
    [Header("Meteor")]
    public GameObject[] meteorPrefabs;
    public float horizontalPosition = 10f;
    public float verticalRange = 4f;
    [Header("UI")]
    public Text scoreText;
    public Text messageText;
    public Button continueButton;
    public GameObject lifeCounter;
    public GameObject lifePrefab;

    private int score;
    private float spawnTimer;
    private float maxSpawnDuration = 1f;
    private float minSpawnDuration = 0.3f;
    private float gameTimer;
    private float gameDuration = 60f;

    // Use this for initialization
    void Start () {
        spawnTimer = maxSpawnDuration;
        for(int i = 0; i < player.lives; ++i) {
            Instantiate(lifePrefab, lifeCounter.transform);
        }
        player.OnShipHit += OnShipHit;
        messageText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;
        gameTimer += Time.deltaTime;
        float difficulty = Mathf.Min(gameTimer / gameDuration, 1f);
        if(spawnTimer <= 0) {
            spawnTimer = maxSpawnDuration - (maxSpawnDuration - minSpawnDuration) * difficulty;
            GameObject meteorPrefab = meteorPrefabs[Random.Range(0, meteorPrefabs.Length)];
            GameObject meteorInstance = Instantiate(meteorPrefab);
            meteorInstance.transform.SetParent(transform);
            meteorInstance.transform.position = new Vector3(horizontalPosition, Random.Range(-verticalRange, verticalRange), 0);
        }
        if (player != null) {
            score = (int) gameTimer * 10;
            scoreText.text = "Placar: " + score;
        }
	}

    void OnShipHit() {
        GameObject lifeCountInstance = lifeCounter.GetComponentInChildren<Image>().gameObject;
        Destroy(lifeCountInstance);
        if(player.lives <= 0) {
            scoreText.gameObject.SetActive(false);
            messageText.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(true);
            messageText.text = string.Format(messageText.text, score);
            GameObject explosionInstance = Instantiate(explosionPrefab, transform);
            explosionInstance.transform.position = player.transform.position;
            Destroy(explosionInstance, 2f);
        } else {
            GameObject damageInstance = Instantiate(damagePrefab, transform);
            damageInstance.transform.position = player.transform.position;
            Destroy(damageInstance, 2f);
            if(player.lives == 2) {
                player.smallDamage.SetActive(true);
            } else if(player.lives == 1) {
                player.smallDamage.SetActive(false);
                player.bigDamage.SetActive(true);
            }
        }
    }

    public void OnContinue() {
       PlayerPrefs.SetInt("score1", score);
       SceneManager.LoadScene("Cine2");
    }
}
