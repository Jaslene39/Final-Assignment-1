using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helicopter : MonoBehaviour
{
    public float fallSpeed = 5f; // Base falling speed
    public float increaseSpeedFactor = 2f; // Factor by which speed increases on wrong answer
    
    public Image explode; // Reference to the bomb UI Image

    public PlayerController _playerController;

    private bool isFalling = false;
    private float currentFallSpeed;

    void Start()
    {
        currentFallSpeed = fallSpeed;
        isFalling = true;
        if (explode != null)
        {
            explode.gameObject.SetActive(false); // Hide the bomb image at the start
        }
    }

    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

            // Check if helicopter has hit the ground (houses)
            // if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1f))
            // {
            //     if (hitInfo.transform.CompareTag("House"))
            //     {
            //         // Decrease player lives
            //         lives--;

            //         // Reset falling state and reposition helicopter
            //         isFalling = false;
                    
            //         if (explode != null)
            //         {
            //             explode.gameObject.SetActive(true); // Show the bomb image
            //         }
                    
            //         // Add delay before starting fall again
            //         StartCoroutine(RestartFall());

            //         // Check for game over
            //         if (lives <= 0)
            //         {
            //             Debug.Log("Game Over");
            //             // Implement game over logic here (e.g., show game over screen, restart level, etc.)
            //             // For now, just stop falling
            //             isFalling = false;
            //             // Optionally, you can add more game over handling logic here
            //         }
            //     }
            // }
        }
    }

    // This function sets up a delay before the helicopter starts falling again
    private IEnumerator RestartFall()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay as needed
        
        if (explode != null)
        {
            explode.gameObject.SetActive(false); // Hide the bomb image
        }

        isFalling = true;
        currentFallSpeed = fallSpeed; // Reset fall speed
    }

    // Call this method to increase the fall speed on a wrong answer
    public void HandleWrongAnswer()
    {
        currentFallSpeed *= increaseSpeedFactor;
    }

    // Optionally, you can call this method to reset the fall speed on a correct answer
    public void HandleCorrectAnswer()
    {
        currentFallSpeed = fallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "House") {
            // Reset falling state and reposition helicopter
            isFalling = false;
            
            if (explode != null)
            {
                explode.gameObject.SetActive(true); // Show the bomb image
            }

            Destroy(gameObject);
        }
    }
}
