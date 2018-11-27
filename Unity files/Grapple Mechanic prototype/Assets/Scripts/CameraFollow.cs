using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform player;
    

    public float displacementX;
    public float displacementY;
    public float displacementZ;

    public float rotSpeed = 5.0f;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = new Vector3(player.position.x + displacementX, player.position.y + displacementY, player.position.z + displacementZ);

    }

    // Update is called once per frame
    void FixedUpdate () {

        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

        
		
	}
}
