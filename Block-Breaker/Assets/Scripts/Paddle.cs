using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    //configuration parameters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1.5f;
    [SerializeField] float maxX = 14.5f;

    //cache references
    GameStatus gameStatus;
    Ball ballToFollowAuto;

    //state variables

    // Use this for initialization
    void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        ballToFollowAuto = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        ballToFollowAuto = FindObjectOfType<Ball>();
        if (gameStatus.CheckGameState() == GameStatus.GameState.playing) {
            MovePaddle();
        }
        if (gameStatus.GetAutoPlayMode()) {
            transform.position = new Vector2(Mathf.Clamp(ballToFollowAuto.transform.position.x, minX, maxX), transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Bonus") {
            Destroy(collision.gameObject);
            gameStatus.UpdateScore(100);
        }
    }

    private void MovePaddle() {
        if (gameStatus.GetPlayWithMouse()) {
            float xPos = Input.mousePosition.x / Screen.width * screenWidthUnits;
            Vector2 paddlePosition = new Vector2(Mathf.Clamp(xPos, minX, maxX), transform.position.y);
            transform.position = paddlePosition;
        }
        else {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x - 0.25f, minX, maxX), transform.position.y);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x + 0.25f, minX, maxX), transform.position.y);
            }
        }
    }
}
