using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1.0f;
	[SerializeField] float maxSpawnTime = 50.0f;
	[SerializeField] List<GameObject> spawnedObjects = new List<GameObject>();
    float spawnTime;
	// Start is called before the first frame update
	void Start()
    {
	    spawnTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
	}

    // Update is called once per frame
    void Update()
    {
		SpawnObject();
    }

    private void SpawnObject()
    {
        spawnTime -= Time.deltaTime;
        int offsetx = UnityEngine.Random.Range(1, 5);
		int offsetz = UnityEngine.Random.Range(1, 5);
		//Debug.Log(spawnTime);
        if(spawnTime <= 0.0f)
        {
			spawnTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
			Instantiate(spawnedObjects[0], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (transform.forward.z+offsetz)), this.transform.rotation);			
		}
    }
}
