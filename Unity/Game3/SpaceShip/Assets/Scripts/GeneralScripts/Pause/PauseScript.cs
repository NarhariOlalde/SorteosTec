using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPause()
    {
	if (Time.timeScale != 1)
	{
	    Time.timeScale = 1;
	}
	else
	{
	    Time.timeScale = 0;
	}
    }

    public void Pause()
    {
	Debug.Log("Paused");
	//PausePanel.SetActive(true);
	Time.timeScale = 0;
    }

    public void Resume()
    {
	Debug.Log("Resume");
	//PausePanel.SetActive(true);
	Time.timeScale = 1;
    }
}
