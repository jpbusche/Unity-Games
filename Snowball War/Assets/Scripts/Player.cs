using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed; 
    [SerializeField] float jumpForce;
    [SerializeField] float attackRate;
    [SerializeField] string moveAxis;
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode throwBall;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform throwPoint;
    [SerializeField] GameObject snowball;
    [SerializeField] bool facingRight;
    [SerializeField] AudioClip soundEffect;

    Rigidbody2D myRigid;
    Animator myAnim;
    bool onGround;
    float radiusCheck = 0.2f, nextAttack = 0f;

    // Start is called before the first frame update
    void Start() {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float move = Input.GetAxis(moveAxis);
        myRigid.velocity = new Vector2(move * moveSpeed, myRigid.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, ground);
        if(Input.GetKeyDown(jump) && onGround) {
            myRigid.AddForce(new Vector2(0f, jumpForce));
        }
        if(Input.GetKeyDown(throwBall) && Time.time > nextAttack) {
            nextAttack = Time.time + attackRate;
            StartCoroutine(ThrowBall());
        }
        myAnim.SetFloat("Speed", Mathf.Abs(myRigid.velocity.x));
        myAnim.SetBool("Grounded", onGround);
        if((move < 0 && facingRight) || (move > 0 && !facingRight)) Flip();
    }

    void Flip() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator ThrowBall() {
        myAnim.SetTrigger("Throw");
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        yield return new WaitForSeconds(0.1f);
        GameObject ball = (GameObject) Instantiate(snowball, throwPoint.position, throwPoint.rotation);
        ball.transform.localScale = transform.localScale;
    }
}
