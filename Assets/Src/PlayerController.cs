using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Src
{
	public class PlayerController : MonoBehaviour
	{
		[Header("PlayerAttributes")]
		[SerializeField] float movementSpeed = 2.0f;
		[SerializeField][Range(0.1f,1.0f)] float growthRate;
		[SerializeField] List<int> playerSprites = new List<int>();
		[SerializeField] Canvas canvas;
		
		//GameObjects
		GameObject _collidedObject;
		//Flags
		bool _currentCollision;
		bool _paused = false;

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
			MovePlayer();
			if(_currentCollision)
			{
				IncreaseSize(_collidedObject);
			}
			//Refactor into imput check function
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Pause();
			}
		}

		//z and x axis for horizontal
		private void MovePlayer()
		{
			var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
		
			var position = transform.position;
			var newPosz = position.z + z;
			var newPosX = position.x + x;
        
			position = new Vector3(newPosX, 0, newPosz);
			transform.position = position;
		}
		//increase size when eating smaller object
		private void IncreaseSize(GameObject collidedObject)
		{
			//add to players size

			float x = collidedObject.transform.localScale.x * growthRate;
			float y = collidedObject.transform.localScale.y * growthRate;
			float z = collidedObject.transform.localScale.z * growthRate;

			Vector3 collidedTrans = new Vector3(x, y, z);
			float collidedMass = collidedObject.GetComponent<Rigidbody>().mass;
			if(collidedObject.GetComponent<Rigidbody>().mass <= this.GetComponent<Rigidbody>().mass)
			{
				this.gameObject.transform.localScale += collidedTrans;
				this.GetComponent<Rigidbody>().mass += collidedMass;
				_currentCollision = false;
				Destroy(collidedObject);
			}
		}

		private void Pause()
		{
			if(!_paused)
			{
				_paused= true;
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
			else
			{
				_paused = false;
				canvas.gameObject.SetActive(false);
				Time.timeScale = 1;
			}
		}

		void OnCollisionEnter(Collision collision)
		{
			Debug.Log("collided");
			Debug.Log(this);
			_currentCollision = true;
			_collidedObject = collision.gameObject;
		}

		void OnCollisionExit(Collision collision)
		{
			_currentCollision = false;
			_collidedObject = collision.gameObject;
			Debug.Log("Exited collider");
		}
	}
}
