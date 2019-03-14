using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Text[] optionsTexts;
    public KeyCode button;

    int index;

    // Start is called before the first frame update
    void Start() {
        index = 0;
    }

    // Update is called once per frame
    void Update() {
        optionsTexts[index].color = new Color(234f / 255f, 164f / 255f, 164f / 255f);
        float move = Input.GetAxis("JoyVertical");
        if((Input.GetKeyDown(KeyCode.DownArrow) || move > 0f) && index < optionsTexts.Length - 1) {
            optionsTexts[index].color = Color.white;
            index++;
        } else if((Input.GetKeyDown(KeyCode.UpArrow) || move < 0f) && index > 0) {
            optionsTexts[index].color = Color.white;
            index--;
        } else if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick 2 button 0")) {
            if(index == 0) SceneManager.LoadScene("Level");
            else Application.Quit();
        }
    }
}
