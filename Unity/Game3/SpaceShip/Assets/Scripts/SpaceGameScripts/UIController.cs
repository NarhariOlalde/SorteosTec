using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;
    public Sprite SpentLife;
    public Image[] livesImage;

    // Start is called before the first frame update
    void Awake()
    {
	UpdateLives();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	int currentScore = PlayerPrefs.GetInt("score", 0);
        ScoreText.text = "Score: " + currentScore.ToString();
    }

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
}

