using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    private float startDelay = .125f;
    private float spawnInterval = .5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroids", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
    int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
    Instantiate(asteroidPrefabs[asteroidIndex], GenerateRandomVector(), asteroidPrefabs[asteroidIndex].transform.rotation);
    }

    Vector3 GenerateRandomVector()
    {
        float x = Random.Range(-12.5f, 12.5f);
        float y = .1f;  
        float z = 8;  

        return new Vector3(x, y, z);
    }
}
