using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    public float speed;
    public int jumpForce;
    public int health;
    public LayerMask groundLayer;

    bool invunerable = false, onGround;
    float radiusCheck = 1.2f;
    int coins = 0;
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
        float move = Input.GetAxis("Horizontal");
        onGround = Physics2D.OverlapCircle(transform.position, radiusCheck, groundLayer);
        if(Input.GetKeyDown(KeyCode.Space) && onGround) {
            myRigidbody.AddForce(new Vector2(0f, jumpForce));
        } else if(move > 0) {
            myRigidbody.velocity = new Vector2(move * speed, myRigidbody.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        } else if(move < 0) {
            myRigidbody.velocity = new Vector2(move * speed, myRigidbody.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void PlayAnimations() {
        myAnim.SetFloat("VelY", myRigidbody.velocity.y);
        if(!onGround) myAnim.Play("Jump");
        else if(onGround && myRigidbody.velocity.x != 0) myAnim.Play("Run");
        else myAnim.Play("Idle");
    }
}
