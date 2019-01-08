using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private int randomLevel;

    public void OnClick()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Lives", 5);

        randomLevel = Random.Range(1, 3);

        SceneManager.LoadScene(randomLevel);
    }
}
