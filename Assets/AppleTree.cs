using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Prefab for instantiating bad apples
    public GameObject badApplePrefab;

    // Speed at which AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that AppleTree will change directions
    public float changeDirChance = 0.02f;

    // Seconds between Apple instantiations
    public float appleDropDelay = 1f;

    // Chance of spawning a bad apple (between 0 and 1)
    [Range(0, 1)] public float badAppleChance = 0.1f;

    void Start() 
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple() 
    {
        // Decide whether to spawn a regular apple or a bad apple based on the chance
        GameObject appleToSpawn;
        float randomValue = Random.value; // Random value between 0 and 1

        // Spawn a Bad Apple if the random value is less than the bad apple chance
        if (randomValue <= badAppleChance) 
        {
            appleToSpawn = badApplePrefab;
        }
        else // Otherwise, spawn a regular apple
        {
            appleToSpawn = applePrefab;
        }

        // Instantiate the chosen apple prefab at the tree's position
        GameObject apple = Instantiate(appleToSpawn);
        apple.transform.position = transform.position;

        // Schedule the next apple drop
        Invoke("DropApple", appleDropDelay);
    }

    void Update() 
    {
        // Basic movement of the AppleTree
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        // Change directions when the AppleTree reaches the edges
        if (pos.x < -leftAndRightEdge) 
        {
            speed = Mathf.Abs(speed); // Move right
        } 
        else if (pos.x > leftAndRightEdge) 
        {
            speed = -Mathf.Abs(speed); // Move left
        } 
        else if (Random.value < changeDirChance) 
        {
            speed *= -1; // Change direction
        }
    }
    
    void FixedUpdate() 
    {
        // Random direction change logic
        if (Random.value < changeDirChance) 
        {
            speed *= -1;
        }
    }
}
