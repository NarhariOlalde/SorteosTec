using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public GameObject Player;

    public GameObject PlatformPrefab;
    public GameObject SprintPrefab;
    private GameObject Plat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(1, 6) > 1)
        {
            Plat = Instantiate(PlatformPrefab, new Vector2(Random.Range(-12f, 12f), Player.transform.position.y + (10 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
        }
        else
        {
            Plat = Instantiate(SprintPrefab, new Vector2(Random.Range(-12f, 12f), Player.transform.position.y + (10 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
        }
        // Instancia una nueva plataforma antes de destruir la antigua

        // Destruye la plataforma antigua
        Destroy(collision.gameObject);
    }


}
