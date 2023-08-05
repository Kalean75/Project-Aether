using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Src
{
    public class Consumer : MonoBehaviour
    {
        [SerializeField] float growthRate = 0.3f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnCollisionEnter(Collision other)
        {
           GameObject collidedObject = other.gameObject;
            var otherScale = other.transform.localScale;

            float x = otherScale.x * growthRate;
            float y = otherScale.y * growthRate;
            float z = otherScale.z * growthRate;

            Vector3 collidedTrans = new Vector3(x, y, z);

			float collidedMass = collidedObject.GetComponent<Rigidbody>().mass;
			if (other.transform.localScale.x <= this.transform.localScale.x|| collidedObject.GetComponent<Rigidbody>().mass <= this.GetComponent<Rigidbody>().mass)
            {
                this.gameObject.transform.localScale += collidedTrans;
				this.GetComponent<Rigidbody>().mass += collidedMass;
				Destroy(other.gameObject);
            }

        }
    }
}