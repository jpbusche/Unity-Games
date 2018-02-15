using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpawner : MonoBehaviour {

    public float lifeTime = 2f;
    public GameObject soundPrefab;
	// Use this for initialization
	void Start () {
        GameObject soundInstace = Instantiate(soundPrefab);
		Destroy(soundInstace, lifeTime);
	}
}
