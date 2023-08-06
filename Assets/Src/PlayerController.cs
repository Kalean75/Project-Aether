using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Src
{
	public class PlayerController : MonoBehaviour
	{
		[Header("PlayerAttributes")]
		[SerializeField] float movementSpeed = 2.0f;
		[SerializeField] float sprintMovementMultiplier = 10.0f;
		//[SerializeField] List<int> playerSprites = new List<int>();
		[SerializeField] Canvas pauseMenu;
		
		//GameObjects
		GameObject _collidedObject;
		//Flags
		//bool _currentCollision;
		bool _paused = true;

		// Start is called before the first frame update
		void Start()
		{
			this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			Time.timeScale = 0.0f;
		}

		// Update is called once per frame
		void Update()
		{
			if (this.gameObject == null)
			{
				Application.Quit();
			}
			parseInputs();
		}

		private void parseInputs()
		{
			//Refactor into imput check function
			if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1.0f)
			{
				Pause();
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				MovePlayer(movementSpeed * sprintMovementMultiplier * (this.transform.localScale.x / 2));
			}
			else
			{
				MovePlayer(movementSpeed);
			}
		}

		//z and x axis for horizontal
		private void MovePlayer(float movementSpeed)
		{
			var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
		
			var position = transform.position;
			var newPosz = position.z + z;
			var newPosX = position.x + x;
        
			position = new Vector3(newPosX, 0, newPosz);
			//transform.position = position;
			this.GetComponent<Rigidbody>().AddForce(position);
		}
		private void Pause()
		{
			if(!_paused)
			{
				_paused= true;
				pauseMenu.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
			else
			{
				_paused = false;
				pauseMenu.gameObject.SetActive(false);
				Time.timeScale = 1;
			}
		}

		void OnCollisionEnter(Collision collision)
		{
			//Debug.Log("collided");
			//Debug.Log(this);
			//_currentCollision = true;
			_collidedObject = collision.gameObject;
		}

		void OnCollisionExit(Collision collision)
		{
			//_currentCollision = false;
			_collidedObject = collision.gameObject;
			//Debug.Log("Exited collider");
		}
	}
}
