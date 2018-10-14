using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleLatch : MonoBehaviour {

    public Transform anchorPoint;

    private Vector3 playerNode;

    

	// Use this for initialization
	void Start () {

        playerNode = anchorPoint.position;

        GetComponent<SpringJoint>().connectedBody.position = playerNode;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
