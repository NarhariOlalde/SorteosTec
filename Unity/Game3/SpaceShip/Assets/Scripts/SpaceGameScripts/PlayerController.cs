using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject bullet;
    public float moveSpeed = 5.0f; // Speed of the spaceship
    public Button PauseButton;
    public Button PlayButton;

    private void Update()
    {
        MoveSpaceship();
    }

    void MoveSpaceship()
    {
        float horizontalInput = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1; // Move left
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1; // Move right
        }

	if (Input.GetKey(KeyCode.Space))
	{
		if (Time.timeScale != 1)
		{
		    PlayButton.onClick.Invoke();
		}
		else
		{
		    PauseButton.onClick.Invoke();
		}
	    
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
