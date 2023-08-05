using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMatter : MonoBehaviour
{
	[Header("Atrributes of Space debris")]
	[SerializeField] float minimumScale;
	[SerializeField] float maximumScale;
	[SerializeField] float growthRate = 0.3f;
	GameObject collidedObject;
	bool currentCollision;
	// Start is called before the first frame update
	void Start()
    {
        float scale = UnityEngine.Random.Range(maximumScale, minimumScale);
		this.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
		moveMatter();
		if (currentCollision)
		{
			IncreaseSize(collidedObject);
		}
	}

	private void moveMatter()
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
		float collidedMass = collidedObject.GetComponent<Rigidbody>().mass;
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
