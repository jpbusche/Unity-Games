using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Text[] optionsTexts;

    int index;

    // Start is called before the first frame update
    void Start() {
        index = 0;
    }

    // Update is called once per frame
    void Update() {
        optionsTexts[index].color = new Color(234f / 255f, 164f / 255f, 164f / 255f);
        if(Input.GetKeyDown(KeyCode.DownArrow) && index < optionsTexts.Length - 1) {
            optionsTexts[index].color = Color.white;
            index++;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && index > 0) {
            optionsTexts[index].color = Color.white;
            index--;
        } else if(Input.GetKeyDown(KeyCode.Return)) {
            if(index == 0) SceneManager.LoadScene("Level");
            else Application.Quit();
        }
    }
}
