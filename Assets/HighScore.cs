// MODULE PURPOSE: This script handles all events pertaining to setting the high score.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScore : MonoBehaviour
{
    static private TextMeshProUGUI _UI_TEXT;
    static private int _SCORE = 1000; //Initial score is 1000

    void Awake() {
        if (_UI_TEXT == null) {
            //Get proper component for UIText if not found
            _UI_TEXT = GetComponent<TextMeshProUGUI>();
        }

        //If a high score already exists, use it
        if (PlayerPrefs.HasKey("HighScore")) {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        //Set resultant high score
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    //SCORE property
    static public int SCORE {
        //Get _SCORE object
        get { return _SCORE; }
        //Only this script can SET the score
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            //If _UI_TEXT is not null, update and format high score. Otherwise, log error in console
            if (_UI_TEXT != null) {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            } else {
                Debug.LogError("UI Text is null. Make sure HighScore is initialized correctly.");
            }
        }
    }

    //Try to set high score
    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    //Flag to trigger high score reset
    public bool resetHighScoreNow = false;

    //Allows us to reset high score without playing game
    void OnDrawGizmos() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000");
        }
    }
}

