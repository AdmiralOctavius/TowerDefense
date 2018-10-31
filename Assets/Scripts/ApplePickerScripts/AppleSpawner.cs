using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public float timeBetweenSpawn = 2;

    float spawnTime = float.MinValue;

	void Start ()
    {
		
	}
	 
	void Update ()
    {
        if (Time.time - spawnTime >= timeBetweenSpawn)
        {
            spawnTime = Time.time;
            GameObject newApple = Instantiate(objToSpawn, gameObject.transform.position, Quaternion.identity);
            newApple.transform.position += new Vector3(Random.Range(-8.0f, 8), 0, 0);
        }
    }
}
