using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotRockLauncher : MonoBehaviour {

    /// <summary>
    /// This script spawns the rock assets in a random place around a spawn object.
    /// </summary>


    public GameObject hotRock;
    private Transform spawnPointTransform;
    private Vector3 spawnPointVector;
    public float spawnTimeMax = 4.0f;
    private float spawnTime;


	void Start () {

        //Generate a spawn location within a 5 unit radius of the original location

        spawnPointTransform = GetComponent<Transform>();
        spawnPointVector = new Vector3(spawnPointTransform.position.x + Random.Range(-5,5), spawnPointTransform.position.y, spawnPointTransform.position.z + Random.Range(-5,5));

        //randomizes the frequency of spawns
        spawnTime = Random.Range(1, spawnTimeMax);
        
        Invoke("Launch", spawnTime);
	}

	void Launch () {

        //Instanciate a prefab of the object and randomise the location of the next one
        Instantiate(hotRock, spawnPointVector, spawnPointTransform.rotation);
        spawnPointVector = new Vector3(spawnPointTransform.position.x + Random.Range(0, 5), spawnPointTransform.position.y, spawnPointTransform.position.z + Random.Range(0, 5));

        Invoke("Launch", spawnTime);
    }


}
