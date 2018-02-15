using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public delegate void ZombieKilledHandler();
    public event ZombieKilledHandler OnZombieKilled;
    public float speed = 2f;
    public GameObject killPrefab;

	// Use this for initialization
	void Start () {
        bool isRight = transform.position.x > 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(isRight ? -speed : speed, 0);
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        if (isRight) {
            sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, sprite.transform.localScale.y, sprite.transform.localScale.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.gameObject.GetComponent<Laser>() != null) {
            GameObject killInstance = Instantiate(killPrefab, transform.parent);
            killInstance.transform.position = transform.position;
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            Destroy(killInstance, 2f);
            if(OnZombieKilled != null) OnZombieKilled();
        }
    }
}
