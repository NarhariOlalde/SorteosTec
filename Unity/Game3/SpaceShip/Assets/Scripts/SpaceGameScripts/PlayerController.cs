using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bullet;
    public float moveSpeed = 5.0f; // Speed of the spaceship

    private void Update()
    {
        MoveSpaceship();
    }

    void MoveSpaceship()
    {
        float horizontalInput = 0;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1; // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1; // Move right
        }

	//if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    
        //	//this.transform.position += Vector3.down * Time.deltaTime * velocity;
	//	Instantiate(bullet, new Vector3(transform.position.x,
        //        	transform.position.y+0.1f, 0), Quaternion.identity);

        //}

        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

}
