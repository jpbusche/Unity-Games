using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public float speed;
    public float radiusCheck = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    bool onGround, isVisible = false;
    Rigidbody2D myRigidbody;
    Animator myAnim;

    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, groundLayer);
        if(!onGround) {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            speed *= -1;
        }
        if(isVisible) myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        else myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y); 
    }

    void OnBecameVisible() {
        Invoke("MoveEnemy", 2f);
    }

    void OnBecameInvisible() {
        Invoke("StopEnemy", 1f);
    }

    void MoveEnemy() {
        isVisible = true;
        myAnim.Play("Run");
    }

    void StopEnemy() {
        isVisible = false;
        myAnim.Play("Idle");
    }
}
