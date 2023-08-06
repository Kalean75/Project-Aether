using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
		//this.transform.position = new Vector3(this.transform.position.x,-480.0f,this.transform.position.z);
	}

	private void Update()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		//this.transform.position = new Vector3(this.transform.position.x, -480.0f, this.transform.position.z);
		this.gameObject.transform.position = new Vector3(player.transform.position.x, -480.0f, player.transform.position.z);
	}
}
