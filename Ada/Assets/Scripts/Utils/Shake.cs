using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    public float intensity;

    private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
            initialPosition.x + Random.Range(-intensity, intensity),
            initialPosition.y + Random.Range(-intensity, intensity),
            initialPosition.z
        );
	}
}
