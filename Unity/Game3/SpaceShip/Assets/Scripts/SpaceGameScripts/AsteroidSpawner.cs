using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid_small;
    public GameObject asteroid_medium;
    public GameObject asteroid_big;
    public float maxWidth;
    public float minWidth;
    public float timeToSpawnMin;
    public float timeToSpawnMax;

    // Probabilities for each asteroid type
    public float smallAsteroidChance = 0.5f;  // 50% chance
    public float mediumAsteroidChance = 0.3f; // 30% chance
    public float bigAsteroidChance = 0.2f;    // 20% chance

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsteroidSpawnerTimer());
    }

    IEnumerator AsteroidSpawnerTimer()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawnMin, timeToSpawnMax));

        float randomValue = Random.value;

        GameObject asteroidToSpawn = null;

        if (randomValue < smallAsteroidChance)
        {
            asteroidToSpawn = asteroid_small;
        }
        else if (randomValue < smallAsteroidChance + mediumAsteroidChance)
        {
            asteroidToSpawn = asteroid_medium;
        }
        else if (randomValue < smallAsteroidChance + mediumAsteroidChance + bigAsteroidChance)
        {
            asteroidToSpawn = asteroid_big;
        }

        if (asteroidToSpawn != null)
        {
            Instantiate(asteroidToSpawn, new Vector3(transform.position.x + Random.Range(minWidth, maxWidth),
                transform.position.y, 0),
                Quaternion.identity);
        }

        StartCoroutine(AsteroidSpawnerTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
