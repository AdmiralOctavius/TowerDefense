using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnRate = 2;

    float spawnTime = float.MinValue;

    void Update()
    {
        if(Time.time - (1/spawnRate) > spawnTime)
        { 
            //Random.insideUnitCircle*15 gives a random point in a circle with a radius of 15 around the center of the world, which will 
            //be outside our camera view, then the asteroid's 'WrapAroundEasy' script will make sure it jumps to the edge of the game area
            GameObject spawnedObj =  Instantiate(prefabToSpawn, Random.insideUnitCircle * 15, Quaternion.identity);

            float rand = Random.Range(.6f, 1);
            spawnedObj.transform.localScale = new Vector3(rand, rand, rand);

            spawnTime = Time.time;
        }
    }
}
