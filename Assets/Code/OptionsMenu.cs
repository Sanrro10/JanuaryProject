using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject mainSettingsContent;
    [SerializeField] GameObject creditsContent;
    

    public void SoundVolume()
    {
        AudioManager.Instance.SoundVolume(volumeSlider.value);
    }

    public void VolumeChanged()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
    
    public void ShowCredits()
    {
        creditsContent.SetActive(true);
        mainSettingsContent.SetActive(false);
    }
    
    public void HideCredits()
    {
        creditsContent.SetActive(false);
        mainSettingsContent.SetActive(true);
    }

    public void Initialize()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        volumeSlider.onValueChanged.AddListener(delegate { VolumeChanged(); });
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

   
}
