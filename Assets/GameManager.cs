using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This method will be called when the game is over
    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Add additional logic for game over, such as stopping time or showing a game over screen
        Time.timeScale = 0; // This stops the game, making everything freeze
    }
}
