using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour {

    [SerializeField]
    private Vector3 playerResetLocation;
    

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
