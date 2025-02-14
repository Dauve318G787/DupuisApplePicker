using UnityEngine;

public class BadApple : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager to end the game

    void Start()
    {
        // Get the reference to the GameManager
        gameManager = Object.FindFirstObjectByType<GameManager>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the BadApple collided with the Basket
        if (other.CompareTag("Basket"))  // Ensure the Basket has the "Basket" tag
        {
            // Notify the GameManager that the game is over
            gameManager.GameOver();
            
            // Optionally, destroy the bad apple object
            Destroy(gameObject);
        }
    }
}
