using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // No changes needed here, we're using TextMeshPro components in ScoreCounter

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;  // Reference to ScoreCounter component for score management

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the ScoreCounter GameObject and get its ScoreCounter script component
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        }
        else
        {
            Debug.LogError("ScoreCounter GameObject not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse
        Vector3 mousePos2D = Input.mousePosition;

        // Set the z value to be negative of the camera's position to match world space
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the 2D mouse position to 3D world position
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Update the basket position to follow the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    // Called when the basket collides with another object
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;

        // If the basket collides with an object tagged as "Apple", destroy the apple and update the score
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);  // Destroy the apple
            scoreCounter.score += 100;  // Increment the score by 100
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
        }

        // If the basket collides with a "BadApple"
        if (collidedWith.CompareTag("BadApple"))
        {
            Destroy(collidedWith);  // Destroy the bad apple
            scoreCounter.score = 0;
        }
    }

}