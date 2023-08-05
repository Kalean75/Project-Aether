using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 5.0f;
	[SerializeField] float maxSpawnTime = 100.0f;
	[SerializeField] List<GameObject> spawnedObjects = new List<GameObject>();
	float i = 5.0f;
	// Start is called before the first frame update
	void Start()
    {
		i = 5.0f;
	}

    // Update is called once per frame
    void Update()
    {
		spawnObject();
    }

    private void spawnObject()
    {
        i -= Time.deltaTime;
        int offset = UnityEngine.Random.Range(1, 20);
        Debug.Log(i);
        if(i <= 0.0f)
        {
            i = 5.0f;
			float spawntime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
			Instantiate(spawnedObjects[0], new Vector3(this.transform.position.x + offset, this.transform.position.y + offset, this.transform.position.z + offset), Quaternion.identity);
		}
    }
}
