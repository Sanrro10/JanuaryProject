using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider BrightnessSlider;

    public void SoundVolume()
    {
        AudioManager.Instance.SoundVolume(volumeSlider.value);
    }

    public void VolumeChanged()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
    
    public void BrightnessChanged()
    {
        PlayerPrefs.SetFloat("brightness", BrightnessSlider.value);
    }

    public void Initialize()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        BrightnessSlider.value = PlayerPrefs.GetFloat("brightness");
        volumeSlider.onValueChanged.AddListener(delegate { VolumeChanged(); });
        BrightnessSlider.onValueChanged.AddListener(delegate { BrightnessChanged(); });
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

   
}
