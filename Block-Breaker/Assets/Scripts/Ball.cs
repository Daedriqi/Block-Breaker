using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    //configuration parameters
    [SerializeField] float yOffset = 2f;
    [SerializeField] GameObject paddle;
    [SerializeField] int launchSpeed = 12;
    [SerializeField] AudioClip ballLaunchSound;
    [SerializeField] float randomFactor = 0.5f;
    //cache references
    AudioSource bounce;
    GameStatus gameStatus;
    Rigidbody2D body;

    //state variables
    bool launched = false;

    // Use this for initialization
    void Start() {
        bounce = GetComponent<AudioSource>();
        gameStatus = FindObjectOfType<GameStatus>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!launched && paddle != null) {
            transform.position = new Vector2(paddle.transform.position.x, yOffset);
            LaunchOnClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        bounce.Play();
        //float randX = UnityEngine.Random.Range(-randomFactor, randomFactor);
        //float randY = UnityEngine.Random.Range(-randomFactor, randomFactor);
        //body.velocity += new Vector2(randX, randY);
        if (body.velocity.x <= 0.5f && body.velocity.x >= -0.5f) {
            if (transform.position.x < Screen.width/2) {
                body.velocity += new Vector2(1, 0);
            }
            else {
                body.velocity += new Vector2(-1, 0);
            }
        }
        if (body.velocity.y <= 0.5f && body.velocity.y >= -0.5f) {
            body.velocity += new Vector2(0, -2);
        }
    }

    private void LaunchOnClick() {
        if (gameStatus.CheckGameState() == GameStatus.GameState.playing && (Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Space))) {
            launched = true;
            body.velocity = new Vector2(0, launchSpeed);
            AudioSource.PlayClipAtPoint(ballLaunchSound, Camera.main.transform.position);
        }
    }
}
