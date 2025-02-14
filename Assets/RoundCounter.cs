using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.SceneManagement; // For scene reloading

public class RoundCounterManager : MonoBehaviour
{
    public TMP_Text roundCounterText; // Reference to the TextMeshPro component
    public GameObject restartButton; // Reference to the restart button UI object
    private int currentRound = 1; // Starting round
    private float timer = 0f; // Timer to track elapsed time
    public float roundDuration = 10f; // Duration for each round in seconds
    private bool gameOver = false; // To track if the game is over

    void Start()
    {
        // Initial update of round counter
        UpdateRoundCounter();
        restartButton.SetActive(false); // Ensure the restart button is hidden at the start
    }

    void Update()
    {
        // If the game is over, stop further updates
        if (gameOver) return;

        // Increment the timer by the time passed each frame
        timer += Time.deltaTime;

        // Check if 10 seconds have passed (or the roundDuration)
        if (timer >= roundDuration)
        {
            // Call NextRound method when the timer reaches or exceeds roundDuration
            NextRound();

            // Reset the timer for the next round
            timer = 0f;
        }
    }

    // This function is called when the round changes
    public void NextRound()
    {
        // If round 4 has been reached, end the game (round 3 must be completed before game is ended)
        if (currentRound >= 3)
        {
            GameOver(); // Call GameOver to end the game
            return;
        }

        currentRound++; // Increment the round
        UpdateRoundCounter(); // Update the UI text
    }

    // Updates the round counter text UI
    private void UpdateRoundCounter()
    {
        roundCounterText.text = "Round: " + currentRound; // Update the text with the current round
    }

    // This method is called when the game is over
    private void GameOver()
    {
        gameOver = true; // Set the game over flag to true
        roundCounterText.text = "Game Over"; // Round counter text becomes Game Over
        
        // Show the restart button
        restartButton.SetActive(true); // Display the Restart button
    }

    // This method will restart the game when the restart button is clicked
    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
