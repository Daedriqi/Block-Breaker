using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonText : MonoBehaviour {
    //configuration parameters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float screenHeighthUnits = 12f;

    //cache references
    Text text;

    //state variables


    // Start is called before the first frame update
    void Start() {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        ChangeTextColorOnMouseOver();
    }

    private void ChangeTextColorOnMouseOver() {
        float mouseX = Input.mousePosition.x / Screen.width * screenWidthUnits;
        float mouseY = Input.mousePosition.y / Screen.height * screenHeighthUnits;
        if (mouseX > 5.5 && mouseX < 10.5 && mouseY > 2.5 && mouseY < 5) {
            text.color = Color.yellow;
        }
        else {
            text.color = Color.white;
        }
    }
}
