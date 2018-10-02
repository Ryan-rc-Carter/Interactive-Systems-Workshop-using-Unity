using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTransform;

    private Rigidbody playerRigidBody;

    [SerializeField]
    [Range(0.1f,200.0f)]
    private float speed = 1.0f;


	// Use this for initialization
	void Start () {

        playerTransform = transform;
        playerRigidBody = playerTransform.transform.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {

      
        //playerTransform.position = playerTransform.position + playerTransform.forward * speed * Time.deltaTime;




        //playerRigidBody.velocity = playerTransform.forward * speed * Time.deltaTime;
        playerRigidBody.AddForce(playerTransform.forward * speed);
	}

         
}
