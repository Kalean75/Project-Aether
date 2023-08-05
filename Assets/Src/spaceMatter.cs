using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMatter : MonoBehaviour
{
	bool currentCollision;
	GameObject collidedObject;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		//currentCollision = true;
		collidedObject = collision.gameObject;
	}

	void OnCollisionExit(Collision collision)
	{
		//currentCollision = false;
		collidedObject = collision.gameObject;
	}
}
