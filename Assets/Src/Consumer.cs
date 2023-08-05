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
            var otherScale = other.transform.localScale;

            float x = otherScale.x * growthRate;
            float y = otherScale.y * growthRate;
            float z = otherScale.z * growthRate;

            Vector3 collidedTrans = new Vector3(x, y, z);
            if (other.transform.localScale.x <= this.transform.localScale.x)
            {
                this.gameObject.transform.localScale += collidedTrans;
                Destroy(other.gameObject);
            }
        }
    }
}