using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenuController : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    public int game_selector;

    private void Awake()
    {
        game_selector = rnd.Next(1, 4);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(game_selector);
    }

    public void QuitGame()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
