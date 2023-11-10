using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenuController : MonoBehaviour
{
    public AudioSource source;
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

	// Cambiar para hacer que lo agarre del API
	PlayerPrefs.SetInt("total_score", PlayerPrefs.GetInt("total_score", 0));

    }

    public void PlayGame()
    {
	source.clip = audio_button_play;
	source.Play();
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
}
