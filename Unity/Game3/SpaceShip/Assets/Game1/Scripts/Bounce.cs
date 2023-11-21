using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public AudioClip bounce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            AudioSource.PlayClipAtPoint(bounce, Camera.main.transform.position, 0.15f);


            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);

        }

    }
}
