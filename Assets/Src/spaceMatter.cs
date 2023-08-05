using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMatter : MonoBehaviour
{
	[Header("Atrributes of Space debris")]
	[SerializeField][Range(0.5f, 20.0f)] float minimumScale;
	[SerializeField][Range(20.5f, 100.0f)] float maximumScale;
	[SerializeField][Range(0.1f, 1.0f)] float growthRate;
	//Gameobjects
	GameObject collidedObject;
	//flags
	bool currentCollision;
	// Start is called before the first frame update
	void Start()
    {
        float scale = Random.Range(maximumScale, minimumScale);
		float mass = scale * 100;
		this.transform.localScale = new Vector3(scale, scale, scale);
		this.GetComponent<Rigidbody>().mass += mass;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
		MoveMatter();
=======
		// moveMatter();
>>>>>>> Stashed changes
		if (currentCollision)
		{
			IncreaseSize(collidedObject);
		}
	}

	private void MoveMatter()
	{
		transform.Translate(transform.forward * Time.deltaTime);
	}

	//increase size when eating smaller object
	private void IncreaseSize(GameObject collidedObject)
	{
		//add to players size

		float x = collidedObject.transform.localScale.x * growthRate;
		float y = collidedObject.transform.localScale.y * growthRate;
		float z = collidedObject.transform.localScale.z * growthRate;

		Vector3 collidedTrans = new Vector3(x, y, z);
		float collidedMass = collidedObject.GetComponent<Rigidbody>().mass * growthRate;
		if (collidedObject.GetComponent<Rigidbody>().mass <= this.GetComponent<Rigidbody>().mass)
		{
			this.gameObject.transform.localScale += collidedTrans;
			this.GetComponent<Rigidbody>().mass += collidedMass;
			currentCollision = false;
			Destroy(collidedObject);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		currentCollision = true;
		collidedObject = collision.gameObject;
	}

	void OnCollisionExit(Collision collision)
	{
		currentCollision = false;
		collidedObject = collision.gameObject;
	}
}
