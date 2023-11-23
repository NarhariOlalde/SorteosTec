using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class GameOverUIController : MonoBehaviour
{
    public Animator corazon1_animator;
    public Animator corazon2_animator;
    public Animator corazon3_animator;
    public Text puntajeFinal;
    public AudioClip loseSound;
    private AudioSource[] allAudioSources;
    public Sprite SpentLife;
    public Image[] livesImage;

    // Start is called before the first frame update
    void Start()
    {
	// DEBUG LINES, DELETE LATER
	//PlayerPrefs.SetInt("lives", 3);
	//animator.SetTrigger("FadeLife3");
	//corazon3_animator.SetTrigger("FadeLife3");
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
        //GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>().StopMusic();
        AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position, 0.5f);
        int currentScore = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("total_score", PlayerPrefs.GetInt("total_score", 0) + currentScore);
        Debug.Log("TOTLA SCORE:" + PlayerPrefs.GetInt("total_score", 0).ToString());
        puntajeFinal.text = "PUNTOS TOTALES: " + currentScore.ToString();
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives", 3) - 1);
	FadeLives();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void FadeLives()
    {
	int lives = PlayerPrefs.GetInt("lives", 3);
	if (lives == 3)
	{
	}
	else if (lives == 2)
	{
	    corazon3_animator.SetTrigger("FadeLife");
	}
	else if (lives == 1)
	{
	    livesImage[2].sprite = SpentLife;
	    corazon2_animator.SetTrigger("FadeLife");
	}
	else if (lives == 0)
	{
	    livesImage[2].sprite = SpentLife;
	    livesImage[1].sprite = SpentLife;
	    corazon1_animator.SetTrigger("FadeLife");
	}
    }

    public void UpdateLives()
    {
	int lives = PlayerPrefs.GetInt("lives", 3);
	if (lives == 3)
	{

	}
	else if (lives == 2)
	{
	    //livesImage[2].sprite = SpentLife;
	}
	else if (lives == 1)
	{
	    livesImage[2].sprite = SpentLife;
	    //livesImage[1].sprite = SpentLife;
	}
	else if (lives == 0)
	{
	    livesImage[2].sprite = SpentLife;
	    //livesImage[1].sprite = SpentLife;
	    //livesImage[0].sprite = SpentLife;
	}
    }
}
