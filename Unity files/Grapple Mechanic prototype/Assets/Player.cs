using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isInRange = false;
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
            m_colliderTransform = other.GetComponent<Transform>();
            m_colliderRigid = other.GetComponent<Rigidbody>();
            m_colliderRigid.isKinematic = false;

            isInRange = true;

        }
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

        Debug.Log("In range and triggered");

        gameObject.AddComponent<HingeJoint>();
        hinge = transform.GetComponent<HingeJoint>();

        hinge.connectedBody = m_colliderRigid;
        hinge.enablePreprocessing = false;
    }

    private void DisConnect()
    {
        Destroy(transform.GetComponent<HingeJoint>());
    }
}
