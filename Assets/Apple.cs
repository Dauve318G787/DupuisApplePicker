// MODULE PURPOSE: This script represents the apples that fall from the apple tree throughout the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //Apples are considered "missed" when they drop below this
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        //If the apple drops below the "missed" position, it is destroyed
        //and it is indicated that a player has missed an apple
        if( transform. position.y < bottomY ) {
            Destroy( this.gameObject );
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
        }
        
    }
}
