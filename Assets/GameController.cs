using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject helicopter;
    public TextMeshProUGUI livesText; // UI Text to display the number of lives
    private int lives = 3; // Total number of lives
    private int xcount;
    private bool gotAnswer = false;

    public void spawnHelicopter() {
        gotAnswer = false;
        Debug.Log("Spawn helicopter");
        xcount = Random.Range(-100, 100);
        Instantiate(helicopter, new Vector2(transform.position.x + xcount, transform.position.y), Quaternion.identity);
    }

    // Set answer choose
    public void chooseAnswer() {
        gotAnswer = true;
    }

    public bool getGotAnswer() {
        return gotAnswer;
    }

    public int getLives() {
        return lives;
    } 

    public void decrementLives() {
        lives--;
        UpdateLivesText(lives);
        if (lives <= 0)
        {
            // Implement game over logic here
            Debug.Log("Game Over");
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
