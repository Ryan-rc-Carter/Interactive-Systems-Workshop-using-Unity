using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleLatch : MonoBehaviour {

    public float orbitSpeed = 5.0f;

    public Transform targetObject;

    private Vector3 targetObjectVector3;


    //private float targetDistance;


    // Use this for initialization
    void Start() {

        targetObjectVector3 = new Vector3(targetObject.position.x, targetObject.position.y, targetObject.position.z);

    }

    // Update is called once per frame
    void FixedUpdate() {


        if (Input.GetKey("space"))
        {


            //targetDistance = Vector3.Distance(targetObject.position, transform.position);


            transform.RotateAround(targetObjectVector3, -Vector3.right, orbitSpeed);
        }
    }
}