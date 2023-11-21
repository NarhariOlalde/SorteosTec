using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public AudioClip shoot;
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
        AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position,0.05f);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
