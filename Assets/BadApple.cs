// MODULE PURPOSE: This script handles events pertaining to the bad apples in the game.

using UnityEngine;

public class BadApple : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the Bad Apple collides with the Basket (assuming the Basket has the "Basket" tag)
        if (other.CompareTag("Basket"))
        {
            // Destroy the bad apple object after collision
            Destroy(gameObject);

            //Instead of a Game Over screen, score is reset to zero and game continues
        }
    }
}
