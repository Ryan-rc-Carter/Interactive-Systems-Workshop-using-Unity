using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private GameObject barrierObject;

    [SerializeField]
    private AudioClip attach;

    [SerializeField]
    private AudioClip detach;

    private Rigidbody self;
    private Rigidbody barrier;
    private Vector3 barrierTransform;
    private bool isInRange = false;
    private Transform m_colliderTransform;
    private Rigidbody m_colliderRigid;
    private HingeJoint hinge;

    private bool connected = false;

    private AudioSource grappleSounds;






    // Use this for initialization
    void Start()
    {

        grappleSounds = GetComponent<AudioSource>();
        self = GetComponent<Rigidbody>();
        barrier = barrierObject.GetComponent<Rigidbody>();
        barrierTransform = barrierObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        self.AddForce(0.0f, 0.0f, Input.GetAxis("Horizontal") * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isInRange)
                Connect();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            DisConnect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grapple Point"))
        {

            m_colliderTransform = other.GetComponent<Transform>();
            m_colliderRigid = other.GetComponent<Rigidbody>();
            m_colliderRigid.isKinematic = false;
            if (other.GetComponent<Light>())
            {
                other.GetComponent<Light>().color = Color.blue;
            }
            isInRange = true;
        }
        else
        {
            SendMessage("Reset");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (connected)
        {
            return;
        }
        else
        { 
            if (other.GetComponent<Light>())
            {
                other.GetComponent<Light>().color = Color.red;
            }
            isInRange = false;
            m_colliderRigid.isKinematic = true;
        }
    }

    private void Connect()
    {
        connected = true;     

        gameObject.AddComponent<HingeJoint>();
        hinge = transform.GetComponent<HingeJoint>();
        hinge.connectedBody = m_colliderRigid;
        hinge.enablePreprocessing = false;
        grappleSounds.clip = attach;
        grappleSounds.Play();
    }

    private void DisConnect()
    {
        Destroy(transform.GetComponent<HingeJoint>());
        connected = false;
        grappleSounds.clip = detach;
        grappleSounds.Play();
    }

    private void Reset()
    {
        self.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        barrier.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
