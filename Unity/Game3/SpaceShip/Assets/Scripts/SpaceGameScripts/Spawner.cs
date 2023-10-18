using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject stars;
    public float maxWidth;
    public float minWidth;
    public float timeToSpawnMin;
    public float timeToSpawnMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerTimer());
    }

    IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawnMin, timeToSpawnMax));

        // Spawn the star at a random x position between minWidth and maxWidth
        GameObject spawnedStar = Instantiate(stars, new Vector3(transform.position.x + Random.Range(minWidth, maxWidth),
            transform.position.y, 0),
            Quaternion.identity);

        // Destroy the spawned star after 5 seconds
        Destroy(spawnedStar, 5f);

        StartCoroutine(SpawnerTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
