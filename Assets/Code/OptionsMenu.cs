using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider BrightnessSlider;

    public AudioSource mainMenuMusic; 

    
    public Slider soundSlider;
    /*
    public void ToggleMusic()
    {
        
        AudioManager.Instance.ToggleSound();
    }*/

    public void SoundVolume()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
        }
        else
        {
            AudioManager.Instance.SoundVolume(volumeSlider.value);
        }
        
    }

    public void VolumeChanged()
    {
        
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainMenuMusic.volume = volumeSlider.value;
        }
        
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
    public void BrightnessChanged()
    {
        PlayerPrefs.SetFloat("brightness", BrightnessSlider.value);
    }
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        BrightnessSlider.value = PlayerPrefs.GetFloat("brightness");
        volumeSlider.onValueChanged.AddListener (delegate {VolumeChanged ();});
        BrightnessSlider.onValueChanged.AddListener (delegate {BrightnessChanged ();});
    }

   
}
