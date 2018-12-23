using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadNextScene() {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    public void LoadStartScene() {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        if (gameStatus != null) {
            gameStatus.ResetGame();
        }
        SceneManager.LoadScene(0);
    }

    private void Update() {

    }
}
