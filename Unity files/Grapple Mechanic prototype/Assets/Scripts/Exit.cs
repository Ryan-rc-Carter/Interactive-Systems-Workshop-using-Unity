using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    /// <summary>
    /// Exits the application when the exit button is clicked
    /// </summary>

	public void OnClick()
    {
        Application.Quit();
    }
}
