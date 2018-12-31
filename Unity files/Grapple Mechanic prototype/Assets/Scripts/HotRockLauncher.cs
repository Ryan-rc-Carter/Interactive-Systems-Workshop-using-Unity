using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotRockLauncher : MonoBehaviour {

    public GameObject hotRock;
    private Transform spawnLocation;
    public float spawnTime = 4.0f;

	// Use this for initialization
	void Start () {
        spawnLocation = GetComponent<Transform>();
        Invoke("Launch", spawnTime);
	}
	
	// Update is called once per frame
	void Launch () {
        Instantiate(hotRock, spawnLocation,true);
        Invoke("Launch", spawnTime);
    }


}
