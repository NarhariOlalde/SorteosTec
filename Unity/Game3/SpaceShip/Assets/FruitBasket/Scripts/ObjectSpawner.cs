using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Y_Gem;
    public GameObject G_Gem;
    public GameObject R_Gem;
    public GameObject B_Gem;
    public GameObject S_Ball;
    public GameObject Heart;
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

        // Probabilities will be used

        int possibleObject = Random.Range(1,7);
        float objPosition = Random.Range(minWidth, maxWidth);

        switch(possibleObject)
        {
            case 1:
                Instantiate(Y_Gem, new Vector3(transform.position.x + objPosition, transform.position.y, 0), Quaternion.identity);
                break;

            case 2:
                Instantiate(G_Gem, new Vector3(transform.position.x + objPosition, transform.position.y, 0), Quaternion.identity);
                break;

            case 3:
                Instantiate(R_Gem, new Vector3(transform.position.x + objPosition, transform.position.y, 0), Quaternion.identity);
                break;

            case 4:
                Instantiate(B_Gem, new Vector3(transform.position.x + objPosition, transform.position.y, 0), Quaternion.identity);
                break;
            
            case 5:
                Instantiate(S_Ball, new Vector3(transform.position.x + objPosition, transform.position.y, 0), Quaternion.identity);
                break;

            case 6:
                Instantiate(Heart, new Vector3(transform.position.x + objPosition, transform.position.y, 0), Quaternion.identity);
                break;
        }

        

        StartCoroutine(SpawnerTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
