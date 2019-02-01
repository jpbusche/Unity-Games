using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpForce;
    public float speed;
    public float radiusCheck = 0.2f;
    public LayerMask groundLayer;
    public int gemCollected = 0;
    public bool isDead = false, won = false;

    bool onGround;
    Rigidbody2D myRigidbody;
    Animator myAnim;

    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        PlayAnimations();
        if(!isDead && !won) {
            onGround = Physics2D.OverlapCircle(transform.position, radiusCheck, groundLayer);
            if(Input.GetKeyDown(KeyCode.Space) && onGround) {
                myRigidbody.AddForce(new Vector2(0f, jumpForce));
            } else if(Input.GetKey(KeyCode.LeftArrow)) {
                myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
                GetComponent<SpriteRenderer>().flipX = false;
            } else if(Input.GetKey(KeyCode.RightArrow)) {
                myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }
        } else {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
    }

    void PlayAnimations() {
        if(isDead) myAnim.Play("Die");
        else if(won) myAnim.Play("Celebrate");
        else if (!onGround) myAnim.Play("Jump");
        else if(onGround && myRigidbody.velocity.x != 0) myAnim.Play("Run");
        else myAnim.Play("Idle");
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Gem")) {
            Destroy(collision.gameObject);
            gemCollected++;
        } else if(collision.gameObject.name == "Exit") {
            won = true;
        } else if(collision.gameObject.name == "BottomWall") {
            isDead = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Monster")) {
            isDead = true;
            Physics2D.IgnoreLayerCollision(9, 10);
        }
        
    }
}

