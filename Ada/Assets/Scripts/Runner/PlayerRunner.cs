using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunner : MonoBehaviour {

    public float jumpSpeed = 9f;
    public float movimentAccelaration;
    public float maxMovimentSpeed = 5f;
    public float raycastDistance = 1.65f;
    
    private bool onGround;
    private float movimentSpeed;
    private Rigidbody2D playerRigibody;
    private bool Pressing {
        get {
            if(Input.GetMouseButtonDown(0)) {
                return true;
            } else {
                return Input.GetKeyDown(KeyCode.Space);
            }
        }
    }

	// Use this for initialization
	void Start () {
        movimentSpeed = maxMovimentSpeed;
		playerRigibody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        movimentSpeed += movimentAccelaration * Time.deltaTime;
        if(movimentSpeed > maxMovimentSpeed) movimentSpeed = maxMovimentSpeed;
        playerRigibody.velocity = new Vector2(movimentSpeed, playerRigibody.velocity.y);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, raycastDistance);
        foreach(RaycastHit2D hit in hits) {
            if(hit.collider.gameObject.tag == "Ground" && onGround == false)  {
                onGround = true;
                gameObject.GetComponent<Animator>().SetBool("OnGround", onGround);
            }
        }
        if(Pressing && onGround) {
            onGround = false;
            gameObject.GetComponent<Animator>().SetBool("OnGround", onGround);
            playerRigibody.velocity = new Vector2(playerRigibody.velocity.x, jumpSpeed);
            gameObject.GetComponent<AudioSource>().Play();
        }
	}

   void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.GetComponent<Obstacle>() != null) {
            Obstacle obstacle = otherCollider.GetComponent<Obstacle>();
            obstacle.Kill();
            movimentSpeed *= 0.1f;
            gameObject.GetComponent<Animator>().SetTrigger("Punch");
        }
   }
}
