using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeParallax : MonoBehaviour {

    public GameObject loopTarget;
    public float loopDistance;
    public float pieceSize;
    public GameObject velocityTarget;
    public float velocityRatio;

    private List<GameObject> pieces;

	// Use this for initialization
	void Start () {
        pieces = new List<GameObject>();
		foreach(SpriteRenderer sprite in gameObject.GetComponentsInChildren<SpriteRenderer>()) {
            pieces.Add(sprite.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject piece in pieces) {
            if(loopTarget.transform.position.x - piece.transform.position.x > loopDistance) {
                piece.transform.localPosition = new Vector3(piece.transform.localPosition.x + pieceSize * pieces.Count, piece.transform.localPosition.y, piece.transform.localPosition.z);
            }
            piece.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityTarget.GetComponent<Rigidbody2D>().velocity.x * velocityRatio, piece.GetComponent<Rigidbody2D>().velocity.y);
        }
	}
}
