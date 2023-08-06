using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class spaceMatter : MonoBehaviour
{
	[Header("Atrributes of Space debris")]
	[SerializeField] float minimumScale;
	[SerializeField] float maximumScale;
	[SerializeField] float moveSpeed = 1.0f;
	GameObject collidedObject;
	//bool currentCollision;
	// Start is called before the first frame update
	void Start()
    {
        float scale = UnityEngine.Random.Range(maximumScale, minimumScale);
		this.transform.localScale = new Vector3(scale, scale, scale);
		this.GetComponent<Rigidbody>().mass = this.transform.localScale.x * 5;
		this.GetComponent<Rigidbody>().freezeRotation = true;
	}

    // Update is called once per frame
    void Update()
    {
		moveMatter();
	}

	private void moveMatter()
	{

		//this.GetComponent<Rigidbody>().MovePosition(transform.forward * moveSpeed * Time.deltaTime);
		//transform.Translate((transform.forward * moveSpeed  * Time.deltaTime));
		this.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
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
