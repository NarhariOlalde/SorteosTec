using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObject : MonoBehaviour
{
    public float velocity = 100;


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
            GameObject.Destroy(this.gameObject);
        }
    }
}
