using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This method will be called when the game is over
    public void GameOver()
    {
        // Display a message or trigger any other actions (such as stopping the game)
        Debug.Log("Game Over!");

        // Stop the game by setting time scale to 0 (this freezes everything)
        Time.timeScale = 0; 

        // Optionally, show a Game Over UI or restart the game
        // You could display a UI panel here, etc.
    }
}
