using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnTime = 5f, spawnCounter = 0f;
    public int maxRandomSpawnCount = 4;
    [SerializeField] Transform leftBorder, rightBorder;
    [SerializeField] GameObject[] allAsteroids;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnCo");
    }

    public void SpawnAsteroid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(leftBorder.position.x, rightBorder.position.x), 0f, transform.position.z);
        var obj = Instantiate(allAsteroids[Random.Range(0, allAsteroids.Length)], spawnPosition, transform.rotation);
        obj.GetComponent<Asteroid>().RandomizeRotationSpeeds();
        obj.GetComponent<Asteroid>().RandomizeDirection();
    }

    IEnumerator SpawnCo()
    {
        float timeMod = Mathf.Clamp(spawnTime / spawnCounter, 0.25f, spawnTime);
        yield return new WaitForSeconds(spawnTime );
        int ranNr = Random.Range(1, maxRandomSpawnCount);
        for (int i = 0; i < ranNr; i++)
        {
            SpawnAsteroid();
        }
        spawnCounter++;
        StartCoroutine("SpawnCo");
    }
}
