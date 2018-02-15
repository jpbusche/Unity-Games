using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParallax : MonoBehaviour {

    public GameObject parallaxPrefab;
    public float speed = 5f;
    public int amount;
    public float size;
    public float offset;
    public float parallaxLimit = 17f;

    private List<GameObject> parallaxInstances;

	// Use this for initialization
	void Start () {
        parallaxInstances = new List<GameObject>();
		for(int i = 0; i < amount; ++i) {
            GameObject parallaxInstance = Instantiate(parallaxPrefab);
            parallaxInstance.transform.SetParent(transform);
            parallaxInstance.transform.position = new Vector3(offset + size * i, 0, 0);
            parallaxInstances.Add(parallaxInstance);
        }
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject currentParallax in parallaxInstances) {
            currentParallax.transform.position = new Vector3(currentParallax.transform.position.x - (speed * Time.deltaTime), currentParallax.transform.position.y, currentParallax.transform.position.z);
            if(currentParallax.transform.position.x < -parallaxLimit) {
                currentParallax.transform.position = new Vector3(currentParallax.transform.position.x + (amount * size), currentParallax.transform.position.y, currentParallax.transform.position.z);
            }
        }
	}
}
