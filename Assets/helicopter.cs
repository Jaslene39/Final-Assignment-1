using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Helicopter : MonoBehaviour
{
    public float fallSpeed = 5f; // Base falling speed
    public float increaseSpeedFactor = 2f; // Factor by which speed increases on wrong answer
    public Sprite explodedHelicopter;

    GameController _gameController;
    private bool isFalling = false;
    private float currentFallSpeed;
    private bool hasCollided = false; // Flag to check if collision has already occurred

    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        currentFallSpeed = fallSpeed;
        isFalling = true;
    }

    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "House" && !hasCollided) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = explodedHelicopter;
            isFalling = false;
            hasCollided = true;
            _gameController.decrementLives();
            Destroy(gameObject, 1);
            
        }
    }
}
