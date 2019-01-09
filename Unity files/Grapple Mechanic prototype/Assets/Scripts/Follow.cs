using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    /// <summary>
    /// This code make the camera look in the direction of the player character.
    /// This is not implemented properly as in the unity editor as the camera is a child of the player object
    /// </summary>

    public Transform player;
    private Transform self;
	
	void Start () {
        self = transform;
	}
	
	void Update ()
    {      
       transform.LookAt(player);
	}
}
