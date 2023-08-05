using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [Header("PlayerAttributes")]
	[SerializeField] float movementSpeed = 2.0f;
    [SerializeField][Range(0.2f,1.0f)] float growthRate = 0.2f;
	[SerializeField] List<int> playerSprites = new List<int>();
	[SerializeField] Canvas _canvas;
    //GameObjects
    GameObject collidedObject;
    //Flags
	bool currentCollision;
    bool paused = false;

    // Start is called before the first frame update
	void Start()
	{
	}

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject == null)
        {
            Application.Quit();
        }
        movePlayer();
        if(currentCollision)
        {
            IncreaseSize(collidedObject);
        }
        //Refactor into imput check function
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
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
    private void IncreaseSize(GameObject collidedObject)
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

    private void Pause()
    {
        if(!paused)
        {
            paused= true;
	        _canvas.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
        else
        {
            paused = false;
	        _canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
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
