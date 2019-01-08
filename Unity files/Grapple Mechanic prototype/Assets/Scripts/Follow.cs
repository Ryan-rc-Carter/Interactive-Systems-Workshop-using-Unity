using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    private Transform self;


	// Use this for initialization
	void Start () {

        self = transform;

	}
	
	// Update is called once per frame
	void Update ()
    {
       

       transform.LookAt(player);
	}
}
