using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicController : MonoBehaviour {

    public string sceneName;
    private float cinematicTimer = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cinematicTimer -= Time.deltaTime;
        if(Input.GetKeyDown("space")) {
            cinematicTimer = 0.0f;
        }
        if(cinematicTimer <= 0.0f) {
            SceneManager.LoadScene(sceneName);
        }
	}
}
