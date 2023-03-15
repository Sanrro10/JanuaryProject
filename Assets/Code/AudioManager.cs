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
    public String currentMusic;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Debug.Log("Destroying");
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        SelectMusic();
    }

    public void PlayMusic(string name)
    {
        Debug.Log("Searching for " + name);
        AudioClip s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            Debug.Log(musicSource.clip);
            // Debug.Log("Previous clip: " + musicSource.clip.name + " Current clip: " + s.name);
            // if (musicSource.clip.name == s.name)
            // {
            //     Debug.Log("Already playing " + name);
            // }
            // else
            // {
                musicSource.clip = s;
                currentMusic = SceneManager.GetActiveScene().name;
                Debug.Log("Playing " + name);
                musicSource.Play();
            // }

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
        Debug.Log("Selecting music");
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Debug.Log("SEstoy en el main menu");
            PlayMusic("menu_music");
        }
        else if (SceneManager.GetActiveScene().name == "Javi_Easy_Level" || SceneManager.GetActiveScene().name == "Sergio_Easy_Level")
        {
            Debug.Log("estoy en el nivel 1");
            PlayMusic("level_music_1");
        }
        else if (SceneManager.GetActiveScene().name == "Javi_Medium_Level" || SceneManager.GetActiveScene().name == "Sergio_Medium_Level")
        {
            Debug.Log("estoy en el nivel 2");
            PlayMusic("level_music_2");
        }
        else if (SceneManager.GetActiveScene().name == "I�igo_Medium_Level" || SceneManager.GetActiveScene().name == "Javi_Hard_Level")
        {
            PlayMusic("level_music_3");
        }
        else if (SceneManager.GetActiveScene().name == "Sergio_Hard_Level")
        {
            PlayMusic("level_music_4");
        }
        else if (SceneManager.GetActiveScene().name == "I�igo_Hard_Level")
        {
            PlayMusic("level_music_5");
        }
    }

}
