using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
		this.transform.position = new Vector3(this.transform.position.x,-480.0f,this.transform.position.z);
	}

	private void Update()
	{
		this.transform.position = new Vector3(this.transform.position.x, -480.0f, this.transform.position.z);
		this.gameObject.transform.localScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
	}
}
