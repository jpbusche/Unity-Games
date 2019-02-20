using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
    
    public float speed;
    public int health;
    public Transform wallCheck;
    public Transform groundCheck;
    public LayerMask layerMask;

    bool facingRight = true, touchedWall, onGround;
    Rigidbody2D myRigidbody;
    
    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        touchedWall = Physics2D.OverlapCircle(wallCheck.position, 0.2f, layerMask);
        onGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, layerMask);
        if(touchedWall || !onGround) Flip();
        myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
    }

    void Flip() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        speed *= -1;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Attack")) {
            health--;
            StartCoroutine(DamageEffect());
            if(health <= 0) Destroy(gameObject);
        }
    }

    IEnumerator DamageEffect() {
        float actualSpeed = speed;
        speed *= -1;
        GetComponent<SpriteRenderer>().color = Color.red;
        myRigidbody.AddForce(new Vector2(0f, 100f));
        yield return new WaitForSeconds(0.3f);
        speed = actualSpeed;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
