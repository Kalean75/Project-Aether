using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    Vector3 originalScale;
	float originalPos;
	// Start is called before the first frame update
	void Start()
    {
		transform.position = transform.parent.position + transform.localPosition;
	}

    // Update is called once per frame
    void Update()
    {
		//transform.position = transform.parent.position + transform.localPosition;
		transform.localScale = originalScale;
		transform.localPosition = new Vector3(transform.position.x,transform.position.y, originalPos);
	}
}
