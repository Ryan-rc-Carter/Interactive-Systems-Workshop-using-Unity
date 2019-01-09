using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotRock : MonoBehaviour {

    /// <summary>
    /// This script is for a backdrop asset which is essentially a large flaming rock with a particle effect.
    /// 
    /// </summary>

    private Rigidbody hotRock;

    [SerializeField]
    private float force = 3.0f;    

    [SerializeField]
    private float destroyTime = 4.0f;
    
	void Start () {
        hotRock = GetComponent<Rigidbody>();
        hotRock.AddForce(Vector3.up * force, ForceMode.Impulse);

        
        Invoke("Drop", 3.0f);
        Invoke("Destroy", destroyTime);

	}	

    void Drop() //this function is supposed to increase the mass of the game object's rigidbody so that it falls faster however this is not the case
    {
        hotRock.mass = 100;
    }
     
    void Destroy() //This function destroys the gameobject after a certain amount of time
    {
        Destroy(gameObject);
    }
}
