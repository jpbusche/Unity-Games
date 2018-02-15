using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour {

    public PlayerRunner playerRunner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(playerRunner.transform.position.x, transform.position.y, transform.position.z);
	}
}
