using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class MainMenuController : MonoBehaviour
{

    public Sprite SpentLife;
    public Sprite FullLife;
    public Image[] livesImage;
    public AudioClip audio_button_play;
    private System.Random rnd = new System.Random();
    public int game_selector;

    private void Awake()
    {

        // Resetear total_score a través de varias partidas,
        // puede que lo cambiemos después, o puede que aquí agarre
        // la variable desde el API
        //if (PlayerPrefs.GetInt("firstTime", 1) == 1)
        //{
        //    PlayerPrefs.DeleteAll();
        //    PlayerPrefs.SetInt("firstTime", 0);
        //}
        //PlayerPrefs.DeleteAll();
        game_selector = rnd.Next(1, 4);
	PlayerPrefs.SetInt("score", 0);
	//PlayerPrefs.SetInt("lives", 3);

	PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives", 3));

	// Cambiar para hacer que lo agarre del API
	PlayerPrefs.SetInt("total_score", PlayerPrefs.GetInt("total_score", 0));
	PlayerPrefs.SetFloat("difficulty_multiplier", 1f);
	if (PlayerPrefs.GetString("last_log", "") != DateTime.Now.ToString("yyyy-MM-dd"))
	{
	    Debug.Log("New day, setting lives to 3.");
	    PlayerPrefs.SetString("last_log", DateTime.Now.ToString("yyyy-MM-dd"));
            PlayerPrefs.SetInt("lives",  3);
	}
	//UpdateLives();

    }

    private void Update()
    {
	UpdateLives();
    }
    public void PlayGame()
    {

	if (PlayerPrefs.GetInt("lives", 3) <= 0) 
	{
	    return;
	}
        SceneManager.LoadSceneAsync(game_selector);
    }

    public void QuitGame()
    {
	PlayerPrefs.DeleteAll(); // esto después será salvar el score al API
        Application.Quit();
    }

    // Función para reiniciar todas las PlayerPrefs cada vez que salimos
    // de play mode
    void OnApplicationQuit()
    {
	PlayerPrefs.DeleteAll();
    }

    public void UpdateLives()
    {
	int lives = PlayerPrefs.GetInt("lives", 3);
	if (lives == 3)
	{
	    livesImage[2].sprite = FullLife;
	}
	else if (lives == 2)
	{
	    livesImage[2].sprite = SpentLife;
	    livesImage[1].sprite = FullLife;

	}
	else if (lives == 1)
	{
	    livesImage[2].sprite = SpentLife;
	    livesImage[1].sprite = SpentLife;
	    livesImage[0].sprite = FullLife;
	}
	else if (lives == 0)
	{
	    livesImage[2].sprite = SpentLife;
	    livesImage[1].sprite = SpentLife;
	    livesImage[0].sprite = SpentLife;
	}
    }
}
