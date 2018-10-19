using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    public GameObject grapplePrefab;

    public int spawnAmount = 5;

    private float spawnX = 0.0f;
    private float spawnY = 20.0f;
    private float spawnZ = 1.0f;
    private Quaternion rotation;

    public float spawnInterval = 5.0f;

    // Use this for initialization
    void Start () {
        for(int i = 0; i < spawnAmount; i++)
        {
            Instantiate(grapplePrefab, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
            spawnZ += spawnInterval;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
