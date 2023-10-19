using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float timeToSpawn = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerTimer());
    }

    IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(bullet, new Vector3(transform.position.x,
            transform.position.y, 0),
            Quaternion.identity);
        StartCoroutine(SpawnerTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
