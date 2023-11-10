using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public enum PlayerAnimation { 
        idle,TeusCorriendo
    }
    private float moveSpeed = 10f;

    Animator animatorController;
    void movement()
    {
        float horizontalInput = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1; // Move left

            transform.localScale = new Vector3(-1, 1);
            UpdateAnimation(PlayerAnimation.TeusCorriendo);

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1; // Move right
            transform.localScale = new Vector3(1, 1);
            UpdateAnimation(PlayerAnimation.TeusCorriendo);

        }
        else {
            UpdateAnimation(PlayerAnimation.idle);
        }

        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void UpdateAnimation(PlayerAnimation nameAnimation) {
        switch (nameAnimation) 
        {

            case PlayerAnimation.idle:
                animatorController.SetBool("walking", false);


                break;
             case PlayerAnimation.TeusCorriendo:
                    animatorController.SetBool("walking", true);


                break;


        }

    }
}
