﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTransform;

    private Rigidbody playerRigidbody;

    public GameObject rope;
   
    private bool inRange = false;

    private float grappleDistance = 0.5f;


    GameObject closest = null;

    private bool isHinge = false;

    private HingeJoint hj;


    private GameObject grapplePoint;

    private Vector3 startPosition;
    private Quaternion startRotation;
    public Material inRangeMaterial;
    public Material outOfRangeMaterial;






    [SerializeField]
    [Range(1.0f,100.0f)]
    private float speed = 5;



	// Use this for initialization
	void Start () {

        playerRigidbody = GetComponent<Rigidbody>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        

   
		
	}
	
	// Update is called once per frame
	void Update () {


        float z = Input.GetAxis("Vertical") * speed;


        playerRigidbody.AddForce(0.0f, 0.0f, z);



        if (Input.GetKeyDown("space"))
        {
            if (inRange)
            {
              

                Connect();
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            isHinge = false;
            Destroy(hj);

            

            Destroy(GameObject.FindGameObjectWithTag("Rope"));
        }




    }

    private void Connect()
    {
        

        grappleDistance = Vector3.Distance(grapplePoint.transform.position, transform.position);

        hj = gameObject.AddComponent<HingeJoint>();

        GetComponent<HingeJoint>().autoConfigureConnectedAnchor = false;

        GetComponent<HingeJoint>().connectedBody = grapplePoint.GetComponent<Rigidbody>();

        GetComponent<HingeJoint>().anchor = new Vector3(0.0f, y: grappleDistance, z: 0.0f);

        GetComponent<HingeJoint>().connectedAnchor = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Grapple Point"))
        {
            inRange = true;
            print(inRange);
            grapplePoint = other.gameObject;
            other.GetComponent<Renderer>().material = inRangeMaterial;
            other.GetComponent<Light>().color = Color.blue;
        }
        else
        {

            print("Reset");
            transform.position = startPosition;
            playerRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            playerRigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            transform.rotation = startRotation;
            
        }
        

        
         



    }

    private void OnTriggerExit(Collider other)
    {

        inRange = false;
        other.GetComponent<Renderer>().material = outOfRangeMaterial;
        other.GetComponent<Light>().color = Color.red;


    }



}