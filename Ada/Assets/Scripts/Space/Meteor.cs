using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    [Header("Gameplay")]
    public float minimumVelocity = 3f;
    public float maximumVelocity = 6f;
    public float lifeTime = 8f;
    public float maxAngularSpeed = 180f;

    private float angularSpeed;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        angularSpeed = Random.Range(-maxAngularSpeed, maxAngularSpeed);
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Random.Range(minimumVelocity, maximumVelocity), 0);
        Destroy(gameObject, lifeTime);
	}

    void Update() {
        spriteRenderer.transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
    }

}
