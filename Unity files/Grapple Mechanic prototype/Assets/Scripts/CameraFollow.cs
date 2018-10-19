using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform player;

    public float displacementX;
    public float displacementY;
    public float displacementZ;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = new Vector3(player.position.x - displacementX, player.position.y - displacementY, player.position.z - displacementZ);


		
	}
}
