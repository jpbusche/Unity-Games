using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed; 
    [SerializeField] float jumpForce;
    [SerializeField] float radiusCheck;
    [SerializeField] string moveAxis;
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode throwBall;
    [SerializeField] LayerMask ground;

    Rigidbody2D myRigid;
    Animator myAnim;
    bool facingRight = true, onGround;

    // Start is called before the first frame update
    void Start() {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float move = Input.GetAxis(moveAxis);
        myRigid.velocity = new Vector2(move * moveSpeed, myRigid.velocity.y);
        onGround = Physics2D.OverlapCircle(transform.position, radiusCheck, ground);
        if(Input.GetKeyDown(jump) && onGround) {
            myRigid.AddForce(new Vector2(0f, jumpForce));
        }
        myAnim.SetFloat("Speed", Mathf.Abs(myRigid.velocity.x));
        myAnim.SetBool("Grounded", onGround);
        if((move < 0 && facingRight) || (move > 0 && !facingRight)) Flip();
    }

    void Flip() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
