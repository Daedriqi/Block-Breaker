using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {
    //configuration parameters
    [Range(0.1f, 10)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int score = 0;
    [SerializeField] Text scoreBoard;
    [SerializeField] bool playWithMouse = true;
    [SerializeField] bool autoPlayMode = false;

    //cache references
    System.Random rand = new System.Random(42);

    //state variables
    GameState gameState = GameState.playing;


    private void Awake() {
        int gameStatuses = FindObjectsOfType<GameStatus>().Length;
        if (gameStatuses > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        UpdateScore(0);
    }

    public bool GetPlayWithMouse() {
        return playWithMouse;
    }

    public bool GetAutoPlayMode() {
        return autoPlayMode;
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;
        rand.Next(1, 10);
    }

    public void UpdateScore(int updateValue) {
        score += updateValue;
        scoreBoard.text = "Score: " + score;
    }

    public float GetRandomValue() {
        return rand.Next(0, 9);
    }

    public int GetScore() {
        return score;
    }

    public GameState CheckGameState() {
        return gameState;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }

    public enum GameState {
        playing,
        paused,
        gameOver,
    }

}
