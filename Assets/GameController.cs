using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject helicopter;
    public TextMeshProUGUI livesText; // UI Text to display the number of lives

    private float TimeLeft = 0.1f;
    private int lives = 3; // Total number of lives
    private bool TimerOn = false;
    private int xcount;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn) {
            if (TimeLeft > 0) {
                TimeLeft -= Time.deltaTime;
            } else {
                Debug.Log("Spawn helicopter");
                TimeLeft = 10;
                xcount = Random.Range(-100, 100);

                Instantiate(helicopter, new Vector2(transform.position.x + xcount, transform.position.y), Quaternion.identity);
            }
        }
    }

    public void decrementLives() {
        lives--;
        UpdateLivesText(lives);
        if (lives <= 0)
        {
            // Implement game over logic here
            Debug.Log("Game Over");
            // For now, just stop the game
            Time.timeScale = 0;
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void UpdateLivesText(int lives)
    {
        if (livesText != null)
        {
            livesText.text = string.Format("{0}", lives);
        }
    }
}
