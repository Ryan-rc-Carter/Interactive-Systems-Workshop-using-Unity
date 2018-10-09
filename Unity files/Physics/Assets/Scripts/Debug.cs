using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour {

	private void OnGUI () {

        GUI.Label(new Rect(5, 5, 200, 30), "Horizontal - A + D");
        GUI.Label(new Rect(150, 5, 200, 30), Input.GetAxis("Horizontal").ToString());

        GUI.Label(new Rect(250, 5, 200, 30), "Verticall - A + D");
        GUI.Label(new Rect(350, 5, 200, 30), Input.GetAxis("Vertical").ToString());

    }
}
