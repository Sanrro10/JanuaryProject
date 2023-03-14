using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public AudioClip[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private float timer;

    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    private void Start()
    {
        SelectMusic();
    }

    public void PlayMusic(string name)
    {
        AudioClip s = Array.Find(musicSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s;
            musicSource.Play();
        }

    }

    public void PlaySFX(string name)
    {
        AudioClip s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s);
        }
    }

    public void ToggleSound()
    {
        musicSource.mute = !musicSource.mute;
        sfxSource.mute = !sfxSource.mute;
    }

    public void SoundVolume(float volume)
    {
        musicSource.volume = volume;
        sfxSource.volume = volume;
    }
    public float GetTimer()
    {
        return timer;
    }
    public void SetTimer(float time)
    {
        timer = time;
    }
    public void UpdateTimer()
    {
        timer -= Time.deltaTime;
    }
    public void SelectMusic()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Debug.Log("SEstoy en el main menu");
            PlayMusic("menu_music");
        }
        else if (SceneManager.GetActiveScene().name == "Javi_Easy_level" || SceneManager.GetActiveScene().name == "Sergio_Easy_level")
        {
            Debug.Log("estoy en el nivel 1");
            PlayMusic("level_music_1");
        }
        else if (SceneManager.GetActiveScene().name == "Javi_Medium_level" || SceneManager.GetActiveScene().name == "Sergio_Medium_level")
        {
            Debug.Log("estoy en el nivel 2");
            PlayMusic("level_music_2");
        }
        else if (SceneManager.GetActiveScene().name == "Iñigo_Medium_level" || SceneManager.GetActiveScene().name == "Javi_Hard_level")
        {
            PlayMusic("level_music_3");
        }
        else if (SceneManager.GetActiveScene().name == "Sergio_Hard_level")
        {
            PlayMusic("level_music_4");
        }
        else if (SceneManager.GetActiveScene().name == "Iñigo_Hard_level")
        {
            PlayMusic("level_music_5");
        }
    }

}
