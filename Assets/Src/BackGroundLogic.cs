using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLogic : MonoBehaviour
{
    Vector3 initialPos;
	// Start is called before the first frame update
	void Start()
    {
        Vector3 initialPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        this.transform.position = initialPos;
    }
}
