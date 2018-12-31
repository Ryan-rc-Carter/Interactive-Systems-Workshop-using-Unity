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
    private bool isInRange = false;
    private Transform m_colliderTransform;
    private Rigidbody m_colliderRigid;
    private HingeJoint hinge;
    private AudioSource playerSound;
    private bool connected = false;
    private bool canConnect = false;

    private ParticleSystem trail;







    // Use this for initialization
    void Start()
    {
        playerSound = GetComponent<AudioSource>();
        self = GetComponent<Rigidbody>();

        
        

        trail = GetComponent<ParticleSystem>();
        trail.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        self.AddForce(0.0f, 0.0f, Input.GetAxis("Horizontal") * speed);




        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isInRange)
                if(!connected)
                    Connect();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(isInRange)
                DisConnect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grapple Point"))
        {
            canConnect = true;
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
            connected = false;
            DisConnect();
            SendMessage("Reset");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!connected)
        {
            canConnect = false;
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
        if (canConnect)
        {
            speed = 10.0f;
            playerSound.clip = attach;
            playerSound.Play();
            trail.Play();

            gameObject.AddComponent<HingeJoint>();
            hinge = transform.GetComponent<HingeJoint>();
            hinge.connectedBody = m_colliderRigid;
            hinge.enablePreprocessing = false;

            

            connected = true;
        }
    }

    private void DisConnect()
    {
        if (canConnect)
        {
            speed = 5.0f;
            Destroy(transform.GetComponent<HingeJoint>());
            playerSound.clip = detach;
            playerSound.Play();
            connected = false;
            trail.Stop();


        }
    }

    private void Reset()
    {
        self.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
