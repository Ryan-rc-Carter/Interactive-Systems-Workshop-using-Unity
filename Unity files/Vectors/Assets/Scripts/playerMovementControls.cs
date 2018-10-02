using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementControls : MonoBehaviour {

    private Transform playerTransform;

    private Rigidbody playerRigidbody;

    [SerializeField]
    [Range(1.0f, 100.0f)]
    private float speed;

	// Use this for initialization
	void Start () {
        playerTransform = transform;
        playerRigidbody = playerTransform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

       
		
	}
}
