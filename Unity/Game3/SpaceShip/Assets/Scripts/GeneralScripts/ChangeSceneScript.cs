using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ChangeSceneScript : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    private string currentSceneName;
    public int game_selector;

    private Dictionary<int, string> gameNames = new Dictionary<int, string>()
    {
        {1, "SpaceGameScene"},
        {2, "FruitBasket"},
        {3, "Game2"}
    };

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(WaitAndChooseRandomNumber());
    }

    private IEnumerator WaitAndChooseRandomNumber()
    {
        yield return new WaitForSeconds(15); // Wait for 15 seconds

        string newSceneName;
        do
        {
            game_selector = rnd.Next(1, 4); // Choose a random scene index
            newSceneName = gameNames[game_selector];
        } while (newSceneName == currentSceneName);

        Debug.Log("Switching to scene: " + newSceneName);
        SceneManager.LoadScene(newSceneName);
    }
}
