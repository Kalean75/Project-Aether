using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMatter : MonoBehaviour
{
	[Header("Atrributes of Space debris")]
	[SerializeField] float minimumScale;
	[SerializeField] float maximumScale;
	bool currentCollision;
	GameObject collidedObject;
	// Start is called before the first frame update
	void Start()
    {
        float scale = UnityEngine.Random.Range(maximumScale, minimumScale);
		this.transform.localScale = new Vector3(scale, scale, scale);
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
