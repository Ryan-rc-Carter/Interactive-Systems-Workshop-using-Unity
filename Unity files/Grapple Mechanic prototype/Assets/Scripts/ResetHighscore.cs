using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHighscore : MonoBehaviour {

    [SerializeField]
    private Text highScoreText;

    public void OnClick()
    {
        PlayerPrefs.SetInt("Highscore", 0);

        int tempHighScore = PlayerPrefs.GetInt("Highscore");


        highScoreText.text = "Highscore - " + tempHighScore;
    }
}
