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

    private float startScore = 0.0f;
    private float fallLimit = 18.0f; // La distancia máxima que el jugador puede caer por debajo de topScore

    public Text ScoreText;
    public Sprite SpentLife;
    public Image[] livesImage;

    public void UpdateLives()
    {
	int lives = PlayerPrefs.GetInt("lives", 3);
	if (lives == 3)
	{

	}
	else if (lives == 2)
	{
	    livesImage[2].sprite = SpentLife;
	}
	else if (lives == 1)
	{
	    livesImage[2].sprite = SpentLife;
	    livesImage[1].sprite = SpentLife;
	}
	else if (lives == 0)
	{
	    livesImage[2].sprite = SpentLife;
	    livesImage[1].sprite = SpentLife;
	    livesImage[0].sprite = SpentLife;
	}
    }

    // Start is called before the first frame update
    void Awake()
    {
	UpdateLives();
    }
    void Start()
    {
	Speed *= PlayerPrefs.GetFloat("difficulty_multiplier", 1f);
        rb = GetComponent<Rigidbody2D>();
	startScore = PlayerPrefs.GetInt("score", (int)startScore);
    }

    void Update()
    {
	float topScore = PlayerPrefs.GetInt("score", (int)startScore);
	fallLimit = topScore + 18.0f;

        if (MoveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (rb.velocity.y > 0) //&& transform.position.y > topScore)
        {
            topScore = transform.position.y + startScore;
        }

        // Comprobar si el jugador ha caído por debajo del límite
        if (transform.position.y < topScore - fallLimit)
        {
            // Cargar la escena GameOver
            SceneManager.LoadScene("GameOver");
        }

        ScoreText.text = "Score: " + Mathf.Round(topScore).ToString();
	//startScore = topScore;
	PlayerPrefs.SetInt("score", (int)topScore);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * Speed, rb.velocity.y);
    }
}
