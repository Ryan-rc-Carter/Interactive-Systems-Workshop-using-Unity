using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTransform;

    private Rigidbody playerRigidbody;

    private bool canJump = true;


    [SerializeField]
    [Range(0.0f, 5.0f)]
    private float jumpWait = 3.0f;


    [SerializeField]
    [Range(1.0f,100.0f)]
    private float speed = 5;

    [SerializeField]
    [Range(1.0f, 100.0f)]
    private float jumpForce = 5.0f;

	// Use this for initialization
	void Start () {

        playerRigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;
        bool jump = Input.GetKeyDown("space");

        if ((jump == true) && (canJump = true))
        {
            canJump = false;
            playerRigidbody.AddForce(x, jumpForce, z, ForceMode.Impulse);

            Invoke("JumpWait", jumpWait);
        }

        playerRigidbody.AddForce(x, 0.0f, z);


    }

    private bool JumpWait()
    {
        canJump = true;
        return canJump;
    }
}
