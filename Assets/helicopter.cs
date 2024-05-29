using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helicopter : MonoBehaviour
{
    public float fallSpeed = 5f; // Base falling speed
    public float increaseSpeedFactor = 2f; // Factor by which speed increases on wrong answer
    public int lives = 3; // Player lives

    private bool isFalling = false;
    private float currentFallSpeed;

    public Image explode; // Reference to the bomb UI Image

    // Start is called before the first frame update
    void Start()
    {
        currentFallSpeed = fallSpeed;
        isFalling = true;
        explode.gameObject.SetActive(false); // Hide the bomb image at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

            // Check if helicopter has hit the ground (houses)
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1f))
            {
                if (hitInfo.transform.CompareTag("House"))
                {
                    // Reset falling state and reposition helicopter
                    isFalling = false;
                    transform.position = new Vector3(transform.position.x, 10, transform.position.z); // Reposition above the houses
                    explode.gameObject.SetActive(true); // Show the bomb image
                    // Add delay before starting fall again
                    StartCoroutine(RestartFall());
                }
            }
        }
    }

    // This function sets up a delay before the helicopter starts falling again
    private IEnumerator RestartFall()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay as needed
        isFalling = true;
        currentFallSpeed = fallSpeed; // Reset fall speed
    }
}