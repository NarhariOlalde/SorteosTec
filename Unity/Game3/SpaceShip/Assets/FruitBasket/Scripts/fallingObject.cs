using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallingObject : MonoBehaviour
{
    public float velocity = 200;

    [Range (0, 50)] public int points = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * velocity;
        if (transform.position.y < -7)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Bomb"))
            {
                SceneManager.LoadScene("GameOver");
            }
            GameObject.Destroy(this.gameObject);
            GameBasketController.Instance.UIControl.AddPoints(points);
        }
    }
}
