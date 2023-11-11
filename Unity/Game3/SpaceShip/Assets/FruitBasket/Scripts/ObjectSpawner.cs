using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Y_Gem;
    public GameObject G_Gem;
    public GameObject R_Gem;
    public GameObject S_Ball;
    public float maxWidth;
    public float minWidth;
    public float timeToSpawnMin;
    public float timeToSpawnMax;

    public float YGemChance = 0.5f;  // 50% chance
    public float GGemChance = 0.3f; // 30% chance
    public float RGemChance = 0.2f;    // 20% chance
    public float SBallChance = 0.2f;    // 20% chance

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerTimer());
    }

    IEnumerator SpawnerTimer()
    {
	SBallChance *= PlayerPrefs.GetFloat("difficulty_multiplier", 1f);
        yield return new WaitForSeconds(Random.Range(timeToSpawnMin, timeToSpawnMax) / PlayerPrefs.GetFloat("difficulty_multiplier", 1f));

        // Probabilities will be used

        int possibleObject = Random.Range(1,5);
        float objPosition = Random.Range(minWidth, maxWidth);

        float randomValue = Random.value;

        GameObject gemToSpawn = null;

        if (randomValue < YGemChance)
        {
            gemToSpawn = Y_Gem;
        }
        else if (randomValue < YGemChance + GGemChance)
        {
            gemToSpawn = G_Gem;
        }
        else if (randomValue < YGemChance + GGemChance + RGemChance)
        {
            gemToSpawn = R_Gem;
        }
        else if (randomValue < YGemChance + GGemChance + RGemChance + SBallChance)
        {
            gemToSpawn = S_Ball;
        }

        if (gemToSpawn != null)
        {
            Instantiate(gemToSpawn, new Vector3(transform.position.x + Random.Range(minWidth, maxWidth),
                transform.position.y, 0),
                Quaternion.identity);
        }

        StartCoroutine(SpawnerTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
