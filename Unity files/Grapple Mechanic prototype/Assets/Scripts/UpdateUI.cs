using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

    [SerializeField]
    private Text score;

    [SerializeField]
    private Text Highscore;

    private void Start()
    {
        UpdateScore();
    }

    
    private void UpdateScore()
    {
        score.text = "Score - " + PlayerPrefs.GetInt("Score").ToString();

        if(PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));

            Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
}
