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

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s;
            currentMusic = SceneManager.GetActiveScene().name;
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
    public void SelectMusic()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 0:
                PlayMusic("menu_music");
                break;
            case 1:
                PlayMusic("level_music_1");
                break;
            case 2:
                PlayMusic("level_music_1");
                break;
            case 3:
                PlayMusic("level_music_2");
                break;
            case 4:
                PlayMusic("level_music_2");
                break;
            case 5:
                PlayMusic("level_music_3");
                break;
            case 6:
                PlayMusic("level_music_3");
                break;
            case 7:
                PlayMusic("level_music_4");
                break;
            case 8:
                PlayMusic("level_music_4");
                break;
            default:
                PlayMusic("level_music_5");
                break;
        }
        
    }

}
