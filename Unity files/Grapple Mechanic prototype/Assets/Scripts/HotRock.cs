using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotRock : MonoBehaviour {

    private Rigidbody hotRock;

    [SerializeField]
    private float force = 5.0f;



	// Use this for initialization
	void Start () {
        hotRock = GetComponent<Rigidbody>();
        hotRock.AddForce(Vector3.up, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
