using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public AudioSource source;
    public AudioClip jumpAudio;

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

	    source.clip = jumpAudio;
	    source.Play();

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);

        }

    }
}
