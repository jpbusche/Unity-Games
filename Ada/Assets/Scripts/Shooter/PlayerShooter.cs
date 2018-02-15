using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    public delegate void PlayerKilledHandler();
    public event PlayerKilledHandler OnPlayerKilled;
    [Header("Laser")]
    public GameObject laserPrefab;
    public float cooldownDuration = 0.5f;
    public Vector2 laserSpawnOffset;
    [Header("Gun")]
    public GameObject weapon;
    public GameObject cooldownEffect;

    private float cooldownTimer;
    private bool lookingRight = true;
    private bool PressingRight {
        get {
            if(Input.GetMouseButtonDown(0)) {
                return (Input.mousePosition.x / Screen.width > 0.5f);
            } else {
                return Input.GetKeyDown(KeyCode.RightArrow);
            }
        }
    }
    private bool PressingLeft {
        get {
            if(Input.GetMouseButtonDown(0)) {
                return (Input.mousePosition.x / Screen.width < 0.5f);
            } else {
                return Input.GetKeyDown(KeyCode.LeftArrow);
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0) {
            if (PressingLeft) {
                Shoot(false);
            } else if (PressingRight) {
                Shoot(true);
            }
        } else {
            if (PressingLeft || PressingRight) {
                GameObject cooldownInstance = Instantiate(cooldownEffect, transform.parent);
                cooldownInstance.transform.position = weapon.transform.position;
                Destroy(cooldownEffect, 2f);
                cooldownTimer = cooldownDuration;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider) {
        if (otherCollider.gameObject.GetComponent<Zombie>() != null) {
            if(OnPlayerKilled != null) OnPlayerKilled();
        }
    }

    private void Shoot(bool toRight) {
        GameObject laserInstance = Instantiate(laserPrefab, transform.parent);
        laserInstance.transform.position = new Vector3(transform.position.x + laserSpawnOffset.x * (toRight ? 1 : -1), transform.position.y + laserSpawnOffset.y * (toRight ? 1 : -1), transform.position.z);
        laserInstance.GetComponent<Laser>().Shoot(toRight);
        GetComponent<Animator>().SetTrigger("Shoot");
        cooldownTimer = cooldownDuration;
        if (lookingRight != toRight) {
            lookingRight = toRight;
            GameObject container = transform.GetChild(0).gameObject;
            container.transform.localScale = new Vector3(-container.transform.localScale.x, container.transform.localScale.y, container.transform.localScale.z);
        }
    }
}
