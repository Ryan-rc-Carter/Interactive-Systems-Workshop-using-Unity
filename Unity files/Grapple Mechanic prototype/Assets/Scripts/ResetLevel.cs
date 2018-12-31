using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour {

    private Vector3 playerResetLocation;
    private Vector3 barrierResetLocation;

    public Transform player;

	// Use this for initialization
	void Start () {
        playerResetLocation = player.position;
		
	}
	
	// Update is called once per frame
	private void Reset () {
        player.position = playerResetLocation;
        
	}
}
