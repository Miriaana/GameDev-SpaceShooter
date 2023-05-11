using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnTime = 5f;
    [SerializeField] Transform leftBorder, rightBorder;
    [SerializeField] GameObject[] allAsteroids;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0.5f, spawnTime);   
    }

    public void SpawnAsteroid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(leftBorder.position.x, rightBorder.position.x), 0f, transform.position.z);
        var obj = Instantiate(allAsteroids[Random.Range(0, allAsteroids.Length)], spawnPosition, transform.rotation);
        obj.GetComponent<Asteroid>().RandomizeRotationSpeeds();
        obj.GetComponent<Asteroid>().RandomizeDirection();
    }
}
