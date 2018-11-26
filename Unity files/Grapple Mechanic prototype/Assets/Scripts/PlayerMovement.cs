using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTransform;

    private Rigidbody playerRigidbody;

    public GameObject rope;
   
    private bool inRange = false;

    private float grappleDistance;


    GameObject closest = null;

    private bool isHinge = false;

    private HingeJoint hj;

    public LineRenderer line;


    private GameObject grapplePoint;

    private Vector3 startPosition;
    private Quaternion startRotation;
    public Material inRangeMaterial;
    public Material outOfRangeMaterial;
    private Vector3 grapplePointLocation;
    public Transform eField;
    private Vector3 eFieldStart;
    public GameObject barrier;






    [SerializeField]
    [Range(1.0f,100.0f)]
    private float speed = 5;



	// Use this for initialization
	void Start () {

        playerRigidbody = GetComponent<Rigidbody>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        line.enabled = false;

        eFieldStart = eField.transform.position;

        hj = GetComponent<HingeJoint>();
        hj.breakForce = 0.0f;



   
		
	}
	
	// Update is called once per frame
	void Update () {


        float z = Input.GetAxis("Vertical") * speed;


        playerRigidbody.AddForce(0.0f, 0.0f, z);


        if (Input.GetKeyDown("space"))
        {
            if (inRange)
            {
                line.enabled = true;
                
                Connect();
                line.SetPosition(1, grapplePointLocation);
                
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            if (hj != null)
            {
                GetComponent<HingeJoint>().autoConfigureConnectedAnchor = true;
                GetComponent<HingeJoint>().connectedBody = null;
                hj.breakForce = 0.01f;

                line.enabled = false;
                grappleDistance = 0.0f;

            }

        }




    }

    private void Connect()
    {       

        grappleDistance = Vector3.Distance(transform.position, grapplePoint.transform.position);
       
        
        //line.SetPosition(1, grapplePoint.transform.position);

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
            grapplePointLocation = other.transform.GetComponentInChildren<Transform>().position;

            Vector3 difference = grapplePointLocation - transform.position;

            difference.Normalize();

            float rotationX = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(new Vector3(rotationX, 0.0f, 0.0f));
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime);


        }
        
        if(other.CompareTag("Obstacle"))
        {
            eField.position = eFieldStart;
            print("Reset");
            transform.position = startPosition;
            playerRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            playerRigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            transform.rotation = startRotation;
            
            barrier.SendMessage("Reset");

        }

        if (other.CompareTag("Finish"))
        {
            transform.position = startPosition;
            playerRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            playerRigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            transform.rotation = startRotation;
            eField.position = eFieldStart;
            barrier.SendMessage("Reset");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grapple Point"))
        {
            inRange = false;
            other.GetComponent<Renderer>().material = outOfRangeMaterial;
            other.GetComponent<Light>().color = Color.red;

        }
    }

    private void getRotation()
    {
        
    }


}
