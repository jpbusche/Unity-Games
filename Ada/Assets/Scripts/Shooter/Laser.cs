using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed = 10f;
    public float lifeTime = 2f;

	public void Shoot(bool shootRight) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(shootRight ? speed : -speed, 0);
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        if (shootRight) {
            sprite.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        Destroy(gameObject, lifeTime);
    }
}
