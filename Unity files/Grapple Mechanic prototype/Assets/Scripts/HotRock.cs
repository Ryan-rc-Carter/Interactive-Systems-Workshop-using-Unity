using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotRock : MonoBehaviour {

    private Rigidbody hotRock;

    [SerializeField]
    private float force = 3.0f;

    private bool checkVelocity = false;

    private Vector3 resetVelocity;



	// Use this for initialization
	void Start () {
        hotRock = GetComponent<Rigidbody>();
        hotRock.AddForce(Vector3.up * force, ForceMode.Impulse);
        Invoke("VelocityCheckEnabled", 0.1f);
        resetVelocity = new Vector3(0, 0, 0);
        Invoke("Drop", 3.0f);
        Invoke("Destroy", 10);

	}
	
	// Update is called once per frame
	void Update () {
    }

        
                
            
        
	

    void VelocityCheckEnabled()
    {
        checkVelocity = true;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
