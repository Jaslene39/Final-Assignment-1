using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Helicopter : MonoBehaviour
{
    public float fallSpeed = 10f; // Base falling speed
    public Sprite explodedHelicopter;
    public AudioClip explosionClip;

    GameController _gameController;
    QuizManager _quizManager;
    private bool isFalling = false;
    private float currentFallSpeed;
    private bool hasCollided = false; // Flag to check if collision has already occurred

    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _quizManager = GameObject.FindGameObjectWithTag("QuizController").GetComponent<QuizManager>();
        currentFallSpeed = fallSpeed;
        isFalling = true;
        Debug.Log("is falling " + isFalling);
    }

    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);
        }
    }

    public void DestroyGameObject() {
        isFalling = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = explodedHelicopter;
        this.gameObject.GetComponent<AudioSource>().clip = explosionClip;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 1);
    }

    public void SelfKill() {
        currentFallSpeed = fallSpeed * 80;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!(_gameController.getGotAnswer()) && !hasCollided) {
            _quizManager.processForNextQuestion();
        }

        if (collision.gameObject.tag == "House" && !hasCollided) {
            hasCollided = true;
            _gameController.decrementLives();
            DestroyGameObject();
        }
    }
}
