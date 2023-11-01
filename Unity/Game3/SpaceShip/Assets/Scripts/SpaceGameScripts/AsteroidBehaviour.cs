using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidBehaviour : MonoBehaviour
{
    public int asteroidType;
    public int health;

    public float velocity;

    Vector2 limit;

    // Start is called before the first frame update
    void Start()
    {
        limit = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width,
            Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * velocity;
        if (transform.position.y < -50)
        {
            GameObject.Destroy(this.gameObject);
        }

	if (health <= 0)
	{
	    GameObject.Destroy(this.gameObject);
	}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy(this.gameObject);
            SceneManager.LoadSceneAsync("GameOver");
        }
	else if (collision.gameObject.CompareTag("Bullet"))
	{
            Debug.Log("Collision Bullet");
	    health -= 50;
	    Debug.Log(health);
            //GameObject.Destroy(this.gameObject);
	}
    }
}
