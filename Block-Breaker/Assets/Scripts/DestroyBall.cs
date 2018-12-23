using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyBall : MonoBehaviour {
    //configuration parameters
    [SerializeField] string endGameSceneName = "Game Over";

    //cache references
    Ball[] balls;

    //state variables


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        balls = FindObjectsOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ball" && balls.Length <= 1) {
            SceneManager.LoadScene(endGameSceneName);
        }
        Destroy(collision.gameObject);
    }
}
