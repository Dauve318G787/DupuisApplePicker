// MODULE PURPOSE: This script is the main script that handles events in this game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab; //Defines prefab for basket
    public int numBaskets = 4; //Defines number of baskets that shall appear in game
    public float basketBottomY = -9f; //Defines lowest positions baskets will be displayed
    public float basketSpacingY = 2f; //Defines spacing distance for baskets
    public List<GameObject> basketList; //Creates an array for baskets that will be displayed


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //For each basket in numBaskets...
       for (int i = 0; i < numBaskets; i++) {
        
        //Instantiate a basket
        GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
        Vector3 pos = Vector3.zero;
        //Position basket
        pos.y = basketBottomY + ( basketSpacingY * i );
        tBasketGO.transform.position = pos;
        //Add basket to basketList
        basketList.Add( tBasketGO );
       } 
    }

    public void AppleMissed() {

        //Find apples in scene and add to appleArray
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        //Destroy missed apples
        foreach( GameObject tempGO in appleArray ) {
            Destroy( tempGO );
        }

        //Descrease basket count by 1
        int basketIndex = basketList.Count -1;
        GameObject basketGO = basketList[basketIndex];

        basketList.RemoveAt(basketIndex);
        Destroy( basketGO );

        //If basket count is zero, reload scene (restart game)
        if (basketList.Count == 0) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
