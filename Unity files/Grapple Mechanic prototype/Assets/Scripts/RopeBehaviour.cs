using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehaviour : MonoBehaviour {


    GameObject closest = null;



    private GameObject grapplePoint;

	// Use this for initialization
	void Start () {

        grapplePoint = GameObject.FindGameObjectWithTag("Grapple Point");



        GetComponent<HingeJoint>().connectedBody = grapplePoint.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
