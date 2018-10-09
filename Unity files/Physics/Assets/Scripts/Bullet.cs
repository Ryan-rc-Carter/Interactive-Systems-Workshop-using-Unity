using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody bulletRigidBody;

    public float destroyTime;

	// Use this for initialization
	void Start () {

        bulletRigidBody = GetComponent<Rigidbody>();

        bulletRigidBody.AddForce(transform.forward * 100.0f, ForceMode.Impulse);

        Invoke("DestroyBullet", destroyTime);

		
	}

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
	
}
