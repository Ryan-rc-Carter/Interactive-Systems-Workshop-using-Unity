using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isInRange = false;
    private Transform colliderTransform;
    private Rigidbody colliderRigid;
    private HingeJoint hinge;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Connect();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            DisConnect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Grapple Point"))
        {
            SendMessage("reset");
        }
        else
        {
            colliderTransform = other.GetComponent<Transform>();
            colliderRigid = other.GetComponent<Rigidbody>();
           colliderRigid.isKinematic = false;

            isInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        colliderRigid.isKinematic = true;
    }

    private void Connect()
    {
        if (!isInRange)
        {
            Debug.Log("NOT In range");
            return;
        }

        Debug.Log("In range and triggered");

        gameObject.AddComponent<HingeJoint>();
        hinge = transform.GetComponent<HingeJoint>();

        hinge.connectedBody = colliderRigid;
        hinge.enablePreprocessing = false;
    }

    private void DisConnect()
    {
        Destroy(transform.GetComponent<HingeJoint>());
    }
}
