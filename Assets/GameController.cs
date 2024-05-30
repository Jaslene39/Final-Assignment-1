using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float TimeLeft = 1;
    public GameObject helicopter;
    public TextMeshProUGUI livesText; // UI Text to display the number of lives

    private int lives = 3; // Total number of lives
    private int numQuestion = 10;
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
                TimeLeft = 6;
                numQuestion -= 1;
                xcount = Random.Range(-100, 100);

                Instantiate(helicopter, new Vector2(transform.position.x + xcount, transform.position.y), Quaternion.identity);

                if (numQuestion == 0) {
                    TimerOn = false;
                }
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
