using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrototype : MonoBehaviour
{
    private bool isInRange = false;
    private bool isConnected = false;
    private Transform m_colliderTransform;
    private Rigidbody m_colliderRigid;
    private HingeJoint hinge;

    // Use this for initialization
    void Start ()
    {
        //
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isConnected)
                Connect();
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(isConnected)
                DisConnect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        m_colliderTransform = other.GetComponent<Transform>();
        m_colliderRigid = other.GetComponent<Rigidbody>();
        m_colliderRigid.isKinematic = false;

        isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        m_colliderRigid.isKinematic = true;
    }

    private void Connect()
    {
        if (!isInRange)
        {
            Debug.Log("NOT In range");
            return;
        }

        Debug.Log("In range and trigerred");
        isConnected = true;
        gameObject.AddComponent<HingeJoint>();
        hinge = transform.GetComponent<HingeJoint>();

        hinge.connectedBody = m_colliderRigid;
        hinge.enablePreprocessing = false;
    }

    private void DisConnect()
    {
        isConnected = false;
        Destroy(transform.GetComponent<HingeJoint>());
    }
}
