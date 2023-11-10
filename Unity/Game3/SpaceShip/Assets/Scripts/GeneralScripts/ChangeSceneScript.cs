using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ChangeSceneScript : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    private string currentSceneName;
    public int game_selector;
    public float transitionTime = 1f;

    //private Animator animator;
    public Animator animator;

    private Dictionary<int, string> gameNames = new Dictionary<int, string>()
    {
        {1, "SpaceGameScene"},
        {2, "FruitBasket"},
        {3, "TecJump"}
    };

    // Start is called before the first frame update
    void Start()
    {
	//animator = GetComponent<Animator>();
        currentSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(WaitAndChooseRandomNumber());
    }

    private IEnumerator WaitAndChooseRandomNumber()
    {
        yield return new WaitForSeconds(15 + transitionTime); // Wait for 15 seconds

        string newSceneName;
        do
        {
            game_selector = rnd.Next(1, 4); // Choose a random scene index
            newSceneName = gameNames[game_selector];
        } while (newSceneName == currentSceneName);

        Debug.Log("Switching to scene: " + newSceneName);
	animator.SetTrigger("StartTransition");
        SceneManager.LoadScene(newSceneName);
    }
}
