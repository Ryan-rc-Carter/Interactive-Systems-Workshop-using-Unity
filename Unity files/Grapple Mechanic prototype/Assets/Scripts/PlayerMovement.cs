using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTransform;

    private Rigidbody playerRigidbody;

    public GameObject rope;

    private bool isRope;

    private bool inRange = false;

    private float grappleDistance = 0.5f;


    GameObject closest = null;

    private bool isHinge = false;

    private HingeJoint hj;


    private GameObject grapplePoint;






    [SerializeField]
    [Range(1.0f,100.0f)]
    private float speed = 5;



	// Use this for initialization
	void Start () {

        playerRigidbody = GetComponent<Rigidbody>();

        

   
		
	}
	
	// Update is called once per frame
	void Update () {


        float z = Input.GetAxis("Vertical") * speed;


        playerRigidbody.AddForce(0.0f, 0.0f, z);



        if (Input.GetKeyDown("space"))
        {
            if (inRange)
            {
                isRope = true;


                //Instantiate(rope);

                

                Connect();
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            isHinge = false;
            Destroy(hj);

            isRope = false;

            Destroy(GameObject.FindGameObjectWithTag("Rope"));
        }




    }

    private void Connect()
    {
        //grapplePoint = GameObject.FindGameObjectWithTag("Grapple Point");


        grappleDistance = Vector3.Distance(grapplePoint.transform.position, transform.position);

        hj = gameObject.AddComponent<HingeJoint>();

        GetComponent<HingeJoint>().autoConfigureConnectedAnchor = false;

        GetComponent<HingeJoint>().connectedBody = grapplePoint.GetComponent<Rigidbody>();

        GetComponent<HingeJoint>().anchor = new Vector3(0.0f, grappleDistance, 0.0f);

        GetComponent<HingeJoint>().connectedAnchor = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {

        inRange = true;

        if(GetComponent<HingeJoint>() == true)
            grapplePoint = other.gameObject;
            //GetComponent<HingeJoint>().connectedBody = other.GetComponent<Rigidbody>();


        grapplePoint = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;

        
    }



}
