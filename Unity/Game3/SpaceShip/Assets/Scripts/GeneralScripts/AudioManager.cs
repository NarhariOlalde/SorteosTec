using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _audioClip;
    private void Awake()
    {
        _audioSource.clip = _audioClip;
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!_audioSource.isPlaying) return;
        _audioSource.Play();


    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}// Start is called before the first frame update