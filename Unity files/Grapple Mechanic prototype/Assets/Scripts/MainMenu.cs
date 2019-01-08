using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

    public void OnClick()
    {
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Highscore"))
        {            
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));
        }

        SceneManager.LoadScene(0);
    }
}

