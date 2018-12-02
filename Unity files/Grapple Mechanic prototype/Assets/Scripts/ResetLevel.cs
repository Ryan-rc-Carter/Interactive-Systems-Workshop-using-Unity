using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour {

    private Vector3 playerResetLocation;
    private Vector3 barrierResetLocation;

    public Transform player;
    public Transform barrier;

	// Use this for initialization
	void Start () {
        playerResetLocation = player.position;
        barrierResetLocation = barrier.position;
		
	}
	
	// Update is called once per frame
	private void reset () {
        player.position = playerResetLocation;
        
        barrier.position = barrierResetLocation;
	}
}
