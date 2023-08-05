using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("PlayerAttributes")]
	[SerializeField] float movementSpeed = 2.0f;
    [SerializeField][Range(0.2f,1.0f)] float growthRate = 0.2f;
	[SerializeField] List<int> playerSprites = new List<int>();
	bool currentCollision;
    GameObject collidedObject;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if(currentCollision)
        {
            increaseSize(collidedObject);
        }

	}

    //z and x axis for horizontal
    private void movePlayer()
    {
		var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var newPosz = transform.position.z + z;
        var newPosX = transform.position.x + x;
        transform.position = new Vector3(newPosX, 0, newPosz);
	}
    //increase size when eating smaller object
    private void increaseSize(GameObject collidedObject)
    {
        //add to players size
        //Vector3 size = collidedObject.GetComponent<MeshRenderer>().bounds.size;
        float x = collidedObject.transform.localScale.x * growthRate;
        float y = collidedObject.transform.localScale.y* growthRate;
		float z = collidedObject.transform.localScale.z* growthRate;

		Vector3 collidedTrans = new Vector3(x, y, z);
        if(collidedObject.transform.localScale.x <= this.transform.localScale.x)
        {
			this.gameObject.transform.localScale += collidedTrans;
			currentCollision = false;
			Destroy(collidedObject);
		}
    }

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("collided");
		Debug.Log(this);
		currentCollision = true;
        collidedObject = collision.gameObject;
	}

	void OnCollisionExit(Collision collision)
	{
		currentCollision = false;
		collidedObject = collision.gameObject;
		Debug.Log("Exited collider");
	}
}
