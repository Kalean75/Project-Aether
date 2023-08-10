using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Src
{
    public class Consumer : MonoBehaviour
    {
        [SerializeField] float growthRate = 0.1f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnCollisionEnter(Collision collidedObject)
        {
			//add to players size
            GameObject collidedGO = collidedObject.gameObject;
            if(collidedGO != null && !collidedGO.CompareTag("RightWall") && !collidedGO.CompareTag("BottomWall") && !collidedGO.CompareTag("LeftWall") && !collidedGO.CompareTag("TopWall") && collidedObject.gameObject!= this.gameObject)
            {
				float mass = this.GetComponent<Rigidbody>().mass;
				float collidedMass = collidedGO.GetComponent<Rigidbody>().mass * growthRate;

				float x = collidedObject.transform.localScale.x * growthRate;
				float y = collidedObject.transform.localScale.y * growthRate;
				float z = collidedObject.transform.localScale.z * growthRate;
                Vector3 collidedTrans = new Vector3(x, y, z);
                if(this.transform.localScale.x >= 50.0f)
                {
				    collidedTrans = new Vector3(0.0f, 0.0f, 0.0f);
                    collidedMass = 0.0f;
				}
				if (collidedMass <= mass)
				{
					this.gameObject.transform.localScale += collidedTrans;
					this.GetComponent<Rigidbody>().mass += collidedMass;
                    if(collidedGO.tag == "Player")
                    {
                        //if scale big enough restart
                        if(this.transform.localScale.x > 50)
                        {
							Scene scene = SceneManager.GetActiveScene();
							SceneManager.LoadScene(scene.name);
						}
                        else
                        {
							collidedGO.GetComponent<PlayerController>().gameOver();
						}
                    }
                    else
                    {
						Destroy(collidedGO);
					}
				}
			}
		}
    }
}