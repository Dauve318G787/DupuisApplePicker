using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class RoundCounterManager : MonoBehaviour
{
    public TMP_Text roundCounterText; // Reference to the TextMeshPro component
    private int currentRound = 1; // Starting round
    private float timer = 0f; // Timer to track elapsed time
    public float roundDuration = 10f; // Duration for each round in seconds

    void Start()
    {
        // Initial update of round counter
        UpdateRoundCounter();
    }

    void Update()
    {
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
        currentRound++; // Increment the round
        UpdateRoundCounter(); // Update the UI text
    }

    // Update the round counter text UI
    private void UpdateRoundCounter()
    {
        roundCounterText.text = "Round: " + currentRound; // Update the text with the current round
    }
}
