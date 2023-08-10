using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Src
{
    public class Gravity : MonoBehaviour
    {
        //[SerializeField] private float speedLimit = 100f;
        public Vector3 initialVelocity = new Vector3(0, 0, 0);
        public const float G = 1;
        public Rigidbody Rigidbody => GetComponent<Rigidbody>();

        // Start is called before the first frame update
        void Start()
        {
            Rigidbody.velocity = initialVelocity;
        }
     
        // Update is called once per frame
        void FixedUpdate()
        {
            ApplyForces();
        }


        public void ApplyForces()
        {
            if (this.GetComponentInChildren<Renderer>().isVisible)
            {
				var gravityObjects = new List<Gravity>(GameObject.FindObjectsByType<Gravity>(FindObjectsSortMode.None));

				foreach (var gravityObject in gravityObjects)
				{
					if (gravityObject == this)
					{
						continue;
					}
					Rigidbody.AddForce(CalculateForce(gravityObject.GetComponent<Rigidbody>()));
				}
			} 
        }

        public Vector3 CalculateForce(Rigidbody other) {
            float m1 = this.GetComponent<Rigidbody>().mass;
            float m2 = other.mass;
            float dist = Vector3.Distance(Rigidbody.position, other.position);

            float force = (float) ((G * m1 * m2) / Math.Pow(dist, 2));

            var direction = (other.position - Rigidbody.position);
            var x = direction.x != 0 ? direction.x / Math.Abs(direction.x) : 0;
            var y = direction.y != 0 ? direction.y / Math.Abs(direction.y) : 0;
            var z = direction.z != 0 ? direction.z / Math.Abs(direction.z) : 0;

            direction = new Vector3(x,y,z);

            var result = new Vector3(
                direction.x * force,
               0, //direction.y * force,
                direction.z * force
            );

            return result;
            
        }
    }
}