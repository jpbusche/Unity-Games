using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float screenUnits = 16f;
    public float minX = 1.8f;
    public float maxX = 14.2f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float posX = Input.mousePosition.x / Screen.width * screenUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(posX, minX, maxX);
        transform.position = paddlePos;
    }
}
