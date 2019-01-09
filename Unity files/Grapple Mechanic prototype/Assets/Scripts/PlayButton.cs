using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    /// <summary>
    /// This code is for the play button in the main menue.
    /// It resets the score to 0 and the number of lives to 5, making sure the player
    /// has the full amount of lives at the start of a run 
    /// </summary>
    private int randomLevel;

    public void OnClick()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Lives", 5);

        randomLevel = Random.Range(1, 5);

        SceneManager.LoadScene(randomLevel);
    }
}
