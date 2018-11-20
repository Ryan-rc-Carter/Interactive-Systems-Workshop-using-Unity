using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierReset : MonoBehaviour {

    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Reset()
    {
        transform.position = startPos;
    }
}
