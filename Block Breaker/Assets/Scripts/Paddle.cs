using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float screenUnits = 16;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float posX = Input.mousePosition.x / Screen.width * screenUnits;
        Debug.Log(posX);
        transform.position = new Vector2(posX, transform.position.y);
    }
}
