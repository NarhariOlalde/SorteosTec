using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public Text puntajeFinal;

    // Start is called before the first frame update
    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("total_score", PlayerPrefs.GetInt("total_score", 0) + currentScore);
	Debug.Log("TOTLA SCORE:" + PlayerPrefs.GetInt("total_score", 0).ToString());
	puntajeFinal.text = "PUNTOS TOTALES: " + currentScore.ToString();
	PlayerPrefs.SetInt("score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoHome()
    {
	SceneManager.LoadSceneAsync("MainMenu");
    }
}