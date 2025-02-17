// MODULE PURPOSE: This script handles the score counter that runs while the game is being played.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    [Header("Dynamic")]
    public int score = 0; //Set initial score equal to zero

    public TextMeshProUGUI uiText; //Create object for UI text


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Format score if it is over 1,000
        uiText.text = score.ToString( "#,0" );
    }
}
