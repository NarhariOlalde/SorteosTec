using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * Time.deltaTime * velocity;
        if (transform.position.y > 6)
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	if (collision.gameObject.CompareTag("Asteroid"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
