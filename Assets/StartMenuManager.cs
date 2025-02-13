using UnityEngine;
using UnityEngine.SceneManagement;  // For changing scenes

public class StartMenuManager : MonoBehaviour
{
    // This function will be triggered by the button click
    public void StartGame()
    {
        // Change to the gameplay scene (replace "GameScene" with your actual game scene name)
        SceneManager.LoadScene("SampleScene");
    }
}

