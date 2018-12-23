using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAdvancer : MonoBehaviour {
    //configuration parameters


    //cache references
    SceneLoader sceneLoader;

    //state variables
    public int blockCount;

    // Start is called before the first frame update
    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
        blockCount = FindObjectsOfType<Block>().Length;
    }

    // Update is called once per frame
    void Update() {
        if (blockCount == 0 && SceneManager.GetActiveScene().buildIndex != 0) {
            sceneLoader.LoadNextScene();
        }
    }

    public void BlockDestroyed() {
        blockCount--;
    }
}
