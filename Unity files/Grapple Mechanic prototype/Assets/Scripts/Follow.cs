using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    private Transform self;
    private float selfX, selfY;

	// Use this for initialization
	void Start () {

        self = transform;
        float selfX = self.position.x;
        float selfY = self.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
       

       transform.LookAt(player);
	}
}
