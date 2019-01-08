using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotRock : MonoBehaviour {

    private Rigidbody hotRock;

    [SerializeField]
    private float force = 3.0f;

    

    [SerializeField]
    private float destroyTime = 4.0f;




	// Use this for initialization
	void Start () {
        hotRock = GetComponent<Rigidbody>();
        hotRock.AddForce(Vector3.up * force, ForceMode.Impulse);

        
        Invoke("Drop", 3.0f);
        Invoke("Destroy", destroyTime);

	}
	
	// Update is called once per frame
	void Update () {
    }

    void Drop()
    {
        hotRock.mass = 100;
    }

        
                
            
        
	

   

    void Destroy()
    {
        Destroy(gameObject);
    }
}
