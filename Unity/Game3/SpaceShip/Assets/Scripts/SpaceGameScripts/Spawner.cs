using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject little_star;
    public GameObject medium_star;
    public GameObject moon;
    public float maxWidth;
    public float minWidth;
    public float timeToSpawnMin;
    public float timeToSpawnMax;
    private float lastMoonXPosition = float.MinValue; // Store the last moon's x position
    public float minMoonDistance = 2.0f; // Minimum distance between consecutive moons

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerTimer());
    }

    IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawnMin, timeToSpawnMax));

        // Spawn the little star and medium star as before
        GameObject spawned_little_star = Instantiate(little_star, new Vector3(transform.position.x + Random.Range(minWidth, maxWidth),
            transform.position.y, 0),
            Quaternion.identity);

        GameObject spawned_medium_star = Instantiate(medium_star, new Vector3(transform.position.x + Random.Range(minWidth, maxWidth),
            transform.position.y, 0),
            Quaternion.identity);

        // 10% chance to spawn the moon
        float moonChance = 0.1f;
        if (Random.value < moonChance)
        {
            float newMoonXPosition = transform.position.x + Random.Range(minWidth, maxWidth);

            // Ensure the new moon doesn't spawn too close to the last one
            while (Mathf.Abs(newMoonXPosition - lastMoonXPosition) < minMoonDistance)
            {
                newMoonXPosition = transform.position.x + Random.Range(minWidth, maxWidth);
            }

            GameObject spawned_moon = Instantiate(moon, new Vector3(newMoonXPosition, transform.position.y, 0), Quaternion.identity);
            lastMoonXPosition = newMoonXPosition; // Update the last moon's x position

            Destroy(spawned_moon, 5f);
        }

        // Destroy the spawned stars after 5 seconds
        Destroy(spawned_little_star, 5f);
        Destroy(spawned_medium_star, 5f);

        StartCoroutine(SpawnerTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
