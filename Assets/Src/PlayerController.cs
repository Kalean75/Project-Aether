using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("PlayerAttributes")]
	[SerializeField] float movementSpeed = 2.0f;
    [SerializeField] int[] playerSprites;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
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
}
