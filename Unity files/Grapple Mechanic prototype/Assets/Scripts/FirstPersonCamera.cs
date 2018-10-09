using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {


    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothing = 100.0f;

    [SerializeField]
    [Range(0.0f, 20.0f)]
    private float zDisplacement = 5.0f;

    [SerializeField]
    [Range(0.0f, 20.0f)]
    private float yDisplacement = 5.0f;



    // Update is called once per frame
    void FixedUpdate () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y - yDisplacement, target.position.z - zDisplacement);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));

        
	}
}
