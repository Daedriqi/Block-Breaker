using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //configuration parameters
    [SerializeField] int blockHealth = 2;
    [SerializeField] Sprite broken;
    [SerializeField] AudioClip breakingSound;
    [SerializeField] int pointsPerBlock = 0;
    [SerializeField] GameObject implosionVFX;
    [SerializeField] GameObject bonusDrop;

    //cache references
    GameStatus status;
    LevelAdvancer levelAdvancer;

    //state variables


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        CheckBlockHealth();
    }

    private void CheckBlockHealth() {
        status = FindObjectOfType<GameStatus>();
        if (blockHealth > 1) {
            blockHealth--;
        }
        else {
            DestroyBlock();
        }
        if (blockHealth == 1) {
            GetComponent<SpriteRenderer>().sprite = broken;
        }
    }

    private void DestroyBlock() {
        levelAdvancer = FindObjectOfType<LevelAdvancer>();
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
        status.UpdateScore(pointsPerBlock);
        levelAdvancer.BlockDestroyed();
        GameObject vfx = Instantiate(implosionVFX, transform.position, transform.rotation);
        Destroy(vfx, 1f);
        Destroy(gameObject);
        RandomDrop(status.GetRandomValue());
    }

    public void RandomDrop(float randomVal) {
        if (randomVal > 7.5) {
            Instantiate(bonusDrop, transform.position, transform.rotation);
        }
    }
}
