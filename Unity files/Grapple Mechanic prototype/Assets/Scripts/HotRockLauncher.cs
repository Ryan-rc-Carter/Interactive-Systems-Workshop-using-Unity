using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotRockLauncher : MonoBehaviour {

    public GameObject hotRock;
    private Transform spawnPointTransform;
    private Vector3 spawnPointVector;
    public float spawnTimeMax = 4.0f;
    private float spawnTime;

	// Use this for initialization
	void Start () {
        spawnPointTransform = GetComponent<Transform>();
        spawnPointVector = new Vector3(spawnPointTransform.position.x + Random.Range(0,5), spawnPointTransform.position.y, spawnPointTransform.position.z + Random.Range(0,5));
        spawnTime = Random.Range(1, spawnTimeMax);
        
        Invoke("Launch", spawnTime);
	}
	
	// Update is called once per frame
	void Launch () {
        Instantiate(hotRock, spawnPointVector, spawnPointTransform.rotation);
        spawnPointVector = new Vector3(spawnPointTransform.position.x + Random.Range(0, 5), spawnPointTransform.position.y, spawnPointTransform.position.z + Random.Range(0, 5));

        Invoke("Launch", spawnTime);
    }


}
