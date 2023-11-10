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
	DontDestroyOnLoad();
        game_selector = rnd.Next(1, 4);
	PlayerPrefs.SetInt("score", 0);

    }

    public void PlayGame()
    {
	source.clip = audio_button_play;
	source.Play();
        SceneManager.LoadSceneAsync(game_selector);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
