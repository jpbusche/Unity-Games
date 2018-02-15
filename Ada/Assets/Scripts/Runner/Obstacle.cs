using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public GameObject killPrefab;

	public void Kill() {
        GameObject killInstance = Instantiate(killPrefab, transform.parent);
        killInstance.transform.position = transform.position;
        Destroy(killInstance, 2f);
        Destroy(gameObject);
    }
}
