using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.Networking;
using System.Text;
using System.Runtime.InteropServices;
using System;

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
	public AudioClip musicamenu2;
    public string JSONurl = "http://localhost:3100/api/updateMaxScore";

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
        AudioSource.PlayClipAtPoint(musicamenu2, Camera.main.transform.position, 0.05f);
        int currentScore = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("total_score", PlayerPrefs.GetInt("total_score", 0) + currentScore);
        Debug.Log("TOTLA SCORE:" + PlayerPrefs.GetInt("total_score", 0).ToString());
        puntajeFinal.text = "PUNTOS TOTALES: " + currentScore.ToString();
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives", 3) - 1);
	    FadeLives();
        try
        {
            string cookieName = "idUsuario";
            IntPtr cookiePtr = getCookie(cookieName);

            if (cookiePtr != IntPtr.Zero)
            {
                string cookieValue = Marshal.PtrToStringAnsi(cookiePtr);
                Debug.Log("Cookie Value: " + cookieValue);
                SaveMaxScore(int.Parse(cookieValue), currentScore);
            }
            else
            {
                Debug.Log("Cookie not found or empty");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error getting cookie: " + e.Message);
        }

    }

    [DllImport("__Internal")]
    private static extern IntPtr getCookie(string name);


    // Update is called once per frame
    void Update()
    {

    }

	public void SaveMaxScore(int cookieValue, int currentScore)
	{
        StartCoroutine(SendMaxScoreToServer(cookieValue, currentScore));

	}   

    IEnumerator SendMaxScoreToServer(int userId, int score)
    {
        string url = JSONurl;

        // Create a simple data structure and serialize it to JSON
        string jsonData = JsonUtility.ToJson(new ScoreData(userId, score));
        Debug.Log("JSON data: " + jsonData);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Max score saved successfully");
        }
    }

    // Data structure to hold user ID and score
    [System.Serializable]
    private class ScoreData
    {
        public int id_usuario;
        public int puntuacion_maxima;

        public ScoreData(int userId, int maxScore)
        {
            this.id_usuario = userId;
            this.puntuacion_maxima = maxScore;
        }
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
