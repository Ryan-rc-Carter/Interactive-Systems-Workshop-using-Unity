using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierReset : MonoBehaviour {

    private Vector3 startPos;
    private Animator animator;
    public float moveSpeed;
    private Rigidbody barrierRB;

    

	// Use this for initialization
	void Start () {
        startPos = transform.position;

        barrierRB = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        barrierRB.AddForce(0.0f, 0.0f, moveSpeed);
	}

    void reset()
    {
        
        barrierRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

}
