using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.CompareTag("Player"))
        {
			switch (this.tag)
			{
				case "RightWall":
					collision.transform.position = new Vector3(715.0f,0.0f, collision.transform.position.z);
					break;
				case "TopWall":
					collision.transform.position = new Vector3(collision.transform.position.x,0, 913.0f);
					break;
				case "BottomWall":
					collision.transform.position = new Vector3(collision.transform.position.x,0, -913.0f);
					break;
				case "LeftWall":
					collision.transform.position = new Vector3(-263.0f,0, collision.transform.position.z);
					break;
			}
        }
		else
		{
			collision.rigidbody.AddForce(new Vector3(100.0f, 0, 100.0f));
		}
	}
}
