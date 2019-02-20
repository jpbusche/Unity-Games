using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    public float speed;
    public float attackRate;
    public int jumpForce;
    public int health;
    public bool won = false;
    public LayerMask groundLayer;
    public Transform spawnAttack;
    public GameObject attack;
    public GameObject crown;

    bool invunerable = false, onGround, facingRight = true;
    float radiusCheck = 1.2f, nextAttack = 0f;
    int coins = 0, totalCoins;
    Rigidbody2D myRigidbody;
    Animator myAnim;

    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        totalCoins = PlayerPrefs.GetInt("Player Coins");
    }

    // Update is called once per frame
    void Update() {
        PlayAnimations();
        if(!won) {
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
        } else {
            PlayerPrefs.SetInt("Player Coins", totalCoins + coins);
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
    }

    void PlayAnimations() {
        myAnim.SetFloat("VelY", myRigidbody.velocity.y);
        if(won) myAnim.Play("Won");
        else if(!onGround) myAnim.Play("Jump");
        else if(onGround && myRigidbody.velocity.x != 0) myAnim.Play("Run");
        else myAnim.Play("Idle");
    }

    void Flip() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy") && !invunerable) {
            health--;
            StartCoroutine(DamageEffect());
            if(health <= 0) KingDeath();
        } else if(collision.CompareTag("Exit")) won = true;
        else if(collision.CompareTag("Water")) Destroy(gameObject);
        else if(collision.CompareTag("Coin")) {
            coins++;
            Destroy(collision.gameObject);
        }
        
    }

    void KingDeath() {
        Destroy(gameObject);
        GameObject instance = Instantiate(crown, transform.position, Quaternion.identity);
        instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 100f));
    }

    IEnumerator DamageEffect() {
        invunerable = true;
        for(float i = 0f; i < 1f; i += 0.2f) {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invunerable = false;
    }
}
