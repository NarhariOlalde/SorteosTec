using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Añadido para cambiar de escena

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;

    private float MoveInput;
    private float Speed = 10f;

    private float topScore = 0.0f;
    private float fallLimit = 18.0f; // La distancia máxima que el jugador puede caer por debajo de topScore

    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (MoveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }

        // Comprobar si el jugador ha caído por debajo del límite
        if (transform.position.y < topScore - fallLimit)
        {
            // Cargar la escena GameOver
            SceneManager.LoadScene("GameOver");
        }

        ScoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * Speed, rb.velocity.y);
    }
}
