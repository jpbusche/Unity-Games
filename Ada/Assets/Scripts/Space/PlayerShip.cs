using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public delegate void ShipHitHandler();
    public event ShipHitHandler OnShipHit;
    [Header("Gameplay")]
    public float speed;
    public int lives;
    public string shipName = "Excalibur";
    [Header("Damage")]
    public GameObject smallDamage;
    public GameObject bigDamage;
    [Header("Visual")]
    public float verticalBound = 4f;
    public float rotationAngle = 30f;

    private Rigidbody2D playerRigidbody;
    private bool PressingUp {
        get {
            if(Input.GetMouseButton(0)) {
                return (Input.mousePosition.y / Screen.height > 0.5f);
            } else {
                return Input.GetKey(KeyCode.UpArrow);
            }
        }
    }
    private bool PressingDown {
        get {
            if(Input.GetMouseButton(0)) {
                return (Input.mousePosition.y / Screen.height < 0.5f);
            } else {
                return Input.GetKey(KeyCode.DownArrow);
            }
        }
    }

	// Use this for initialization
	void Start () {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        lives = 3;
        speed = 7f;
        smallDamage.SetActive(false);
        bigDamage.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 targetVelocity = Vector2.zero;
        Quaternion targetRotation = Quaternion.Euler(0, 0, -90);

		if(PressingUp) {
            targetRotation = Quaternion.Euler(0, 0, -90 + rotationAngle);
            targetVelocity = new Vector2(0, speed);
        }
        if(PressingDown) {
            targetRotation = Quaternion.Euler(0, 0, -90 - rotationAngle);
            targetVelocity = new Vector2(0, -speed);
        }
        
        if(transform.position.y > verticalBound) {
            transform.position = new Vector3(transform.position.x, verticalBound, transform.position.z);
        } else if (transform.position.y < -verticalBound) {
            transform.position = new Vector3(transform.position.x, -verticalBound, transform.position.z);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 15);
        playerRigidbody.velocity = targetVelocity;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.gameObject.GetComponent<Meteor>() != null) {
            Destroy(otherCollider.gameObject);
            lives--;
            if(OnShipHit != null) OnShipHit();
            if(lives <= 0) Destroy(gameObject);
        }
    }
}
