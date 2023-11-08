using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;

    // Start is called before the first frame update
    void Awake()
    {
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
}

