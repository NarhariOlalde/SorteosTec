using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SpaceGameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
