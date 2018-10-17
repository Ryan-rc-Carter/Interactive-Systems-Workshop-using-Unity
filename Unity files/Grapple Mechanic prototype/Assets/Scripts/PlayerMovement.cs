using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTransform;

    private Rigidbody playerRigidbody;

    public GameObject rope;

    private bool pointFound;


    GameObject closest = null;

    private bool isHinge = false;

    private HingeJoint hj;







    [SerializeField]
    [Range(1.0f,100.0f)]
    private float speed = 5;



	// Use this for initialization
	void Start () {

        playerRigidbody = GetComponent<Rigidbody>();

        pointFound = false;

   
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        float z = Input.GetAxis("Vertical") * speed;


        playerRigidbody.AddForce(0.0f, 0.0f, z);



        if (Input.GetKeyDown("space"))
        {
            if (pointFound == false)
                ClosestGrapplePoint();


            Instantiate(rope, closest.transform.position, closest.transform.rotation);

            hj = gameObject.AddComponent(typeof(HingeJoint)) as HingeJoint;



        }
        else if (Input.GetKeyUp("space"))
        {
            isHinge = false;
            Destroy(hj);

            Destroy(GameObject.FindGameObjectWithTag("Rope"));
        }




    }

    public GameObject ClosestGrapplePoint()
    {
        GameObject[] points;

        points = GameObject.FindGameObjectsWithTag("Grapple Point");

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach(GameObject gp in points)
        {
            Vector3 diff = gp.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = gp;
                distance = curDistance;
            }
        }


        return closest;
    }


}
