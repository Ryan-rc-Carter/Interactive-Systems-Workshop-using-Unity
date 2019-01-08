using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private int randomLevel;

    public void OnClick()
    {
        randomLevel = Random.Range(1, 2);

        SceneManager.LoadScene(randomLevel);
    }
}
