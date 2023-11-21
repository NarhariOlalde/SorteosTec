using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintBounce : MonoBehaviour
{
    public AudioClip superbounce;
    //public AudioSource source;
    //public AudioClip superJump;
    //public float jumpVolume = 0.05f;

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
	    //source.clip = superJump;
        //source.volume = jumpVolume;
        //source.Play();

        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            AudioSource.PlayClipAtPoint(superbounce, Camera.main.transform.position, 0.15f);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1000f);

        }

    }
}
