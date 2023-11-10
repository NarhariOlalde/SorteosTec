using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text ammountPoints;
    string ammountText = "Points: ";
    private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetInt("score", 0);
        ammountPoints.text = ammountText + currentScore.ToString();
    }

    public void printScore()
    {
        ammountPoints.text = ammountText + currentScore.ToString();
    }

    public void AddPoints(int _points)
    {
        currentScore +=_points;
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0) + currentScore);
        printScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
