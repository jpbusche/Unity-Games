using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    public float speed;
    public float attackRate;
    public int jumpForce;
    public int health;
    public LayerMask groundLayer;
    public Transform spawnAttack;
    public GameObject attack;

    bool invunerable = false, onGround, facingRight = true, attacking = false;
    float radiusCheck = 1.2f, nextAttack = 0f;
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
        myRigidbody.velocity = new Vector2(move * speed, myRigidbody.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && onGround) {
            myRigidbody.AddForce(new Vector2(0f, jumpForce));
        }else if (Input.GetKeyDown(KeyCode.X) && onGround && Time.time > nextAttack) {
            nextAttack = Time.time + attackRate;
            GameObject instance = Instantiate(attack, spawnAttack.position, spawnAttack.rotation);
            if(!facingRight) instance.transform.eulerAngles = new Vector3(180f, 0f, 180f);
            Destroy(instance, 0.3f);
        }
        if((move < 0 && facingRight) || (move > 0 && !facingRight)) Flip();
    }

    void PlayAnimations() {
        myAnim.SetFloat("VelY", myRigidbody.velocity.y);
        if(!onGround) myAnim.Play("Jump");
        else if(onGround && myRigidbody.velocity.x != 0) myAnim.Play("Run");
        else myAnim.Play("Idle");
    }

    void Flip() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
