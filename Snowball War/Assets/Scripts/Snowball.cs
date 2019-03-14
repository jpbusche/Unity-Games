using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] GameObject snowballEffect;

    Rigidbody2D myRigid;

    // Start is called before the first frame update
    void Start() {
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        myRigid.velocity = new Vector2(moveSpeed * transform.localScale.x, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject particle = (GameObject) Instantiate(snowballEffect, transform.position, transform.rotation);
        Destroy(gameObject);  
        Destroy(particle, 1f); 
        if(collision.CompareTag("P1")) FindObjectOfType<LevelController>().Hurt(1);
        else if(collision.CompareTag("P2")) FindObjectOfType<LevelController>().Hurt(2);
    }
}
