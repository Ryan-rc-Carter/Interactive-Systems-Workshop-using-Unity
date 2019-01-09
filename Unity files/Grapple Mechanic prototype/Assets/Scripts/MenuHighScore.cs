using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHighScore : MonoBehaviour {

    [SerializeField]
    private Text highScoreText;

	// Use this for initialization
	void Start () {

        ResetHighScore();

    }
	
	// Update is called once per frame
	public void ResetHighScore() {
        int tempHighScore = PlayerPrefs.GetInt("Highscore");


        highScoreText.text = "Highscore - " + tempHighScore;
    }
}
