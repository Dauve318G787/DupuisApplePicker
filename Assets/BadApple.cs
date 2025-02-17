using UnityEngine;

public class BadApple : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Find the GameManager object in the scene
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the Bad Apple collides with the Basket (assuming the Basket has the "Basket" tag)
        if (other.CompareTag("Basket"))
        {
            // Trigger Game Over
            gameManager.GameOver();
            // Destroy the bad apple object after collision
            Destroy(gameObject);
        }
    }
}
