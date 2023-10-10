using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    #region Variables
    [Header("Level References")]
    [SerializeField] private List<Level> levels = new List<Level>();

    [Header("Player References")]
    [SerializeField] private Player player;

    [Header("Tilemap References")]
    [SerializeField] private TilemapSwitch spikeTilemap;
    [SerializeField] private TilemapSwitch mainTilemap;
    [SerializeField] private Tilemap victoryTilemap;

    [Header("UI References")]
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private TextMeshProUGUI victoryLevelName;
    [SerializeField] private TextMeshProUGUI victoryTouches;
    [SerializeField] private TextMeshProUGUI victoryMinTouches;
    [SerializeField] private GameObject recordImage;
    [SerializeField] private TextMeshProUGUI touchText;
    [SerializeField] private GameObject nextlevelButton;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseOptionsPanel;

    [Header("Options Menu")]
    public OptionsMenu optionsM;

    [Header("Background")]
    [SerializeField] private RawImage BgImg;

    private bool _orangeActive;
    private bool _running;
    private int _currentLevel = 0;

    // Countdown variables
    private int _touches = 0;
    #endregion

    #region UnityMethods
    void Start()
    {
        if (AudioManager.Instance.currentMusic != SceneManager.GetActiveScene().name)
        {
            AudioManager.Instance.SelectMusic();
        }
        optionsM.Initialize();
        ApplySettings();
        _running = true;
        _orangeActive = false;
        mainTilemap.Swap(_orangeActive);
        spikeTilemap.Swap(_orangeActive);
        if (_currentLevel == 0)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i].scene.SceneName == SceneManager.GetActiveScene().name)
                {
                    _currentLevel = i;
                }
            }
        }

        _touches = 0;
        SetTouchText();
    }
    #endregion

    #region PublicMethods
    public bool IsRunning() => _running;
    
    public Player GetPlayer() => player;
    
    public Tilemap GetMainTilemap() => mainTilemap.GetTilemap();
    
    public Tilemap GetSpikeTilemap() => spikeTilemap.GetTilemap();
    
    public Tilemap GetVictoryTilemap() => victoryTilemap;
    
    public void AddTouch()
    {
        _touches++;
        SetTouchText();
    }
    
    public void Die()
    {
        AudioManager.Instance.PlaySFX("player_death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Win()
    {
        AudioManager.Instance.PlaySFX("goal");
        AudioManager.Instance.musicSource.Stop();
        _running = false;
        Time.timeScale = 0;
        UpdateVictoryUI();
        if(levels[_currentLevel].GetMinimumTouches() > _touches || levels[_currentLevel].GetMinimumTouches() == 0)
        {
            levels[_currentLevel].SetTouches(_touches);
        }
        if (_currentLevel < levels.Count - 1)
        {
            levels[_currentLevel + 1].SetUnlocked(true);
            nextlevelButton.SetActive(true);
        }
        victoryUI.SetActive(true);
        gameUI.SetActive(false);
    }
    public void Pause()
    {
        AudioManager.Instance.PlaySFX("button");
        AudioManager.Instance.musicSource.Pause();
        _running = false;
        Time.timeScale = 0;
        pauseOptionsPanel.SetActive(true);
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
    }
    public void Resume()
    {
        AudioManager.Instance.PlaySFX("button");
        AudioManager.Instance.musicSource.Play();
        _running = true;
        Time.timeScale = 1;
        pauseOptionsPanel.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
    }
    public void ReturnFromOptions()
    {
        AudioManager.Instance.PlaySFX("button");
        pauseUI.SetActive(true);
        optionsUI.SetActive(false);
    }
    public void ShowOptionsMenu()
    {
        AudioManager.Instance.PlaySFX("button");
        pauseUI.SetActive(false);
        optionsUI.SetActive(true);
    }
    public void ReturnToMenu()
    {
        AudioManager.Instance.PlaySFX("button");
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        AudioManager.Instance.PlaySFX("button_start_level");
        AudioManager.Instance.SelectMusic();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _touches = 0;
        SetTouchText();
        touchText.text = "Touches: " + _touches;
    }
    public void LoadNextlevel()
    {
        AudioManager.Instance.PlaySFX("button_start_level");
        Time.timeScale = 1;
        levels[_currentLevel + 1].LoadLevel();

    }
    public void SwapTilemaps()
    {
        AddTouch();
        AudioManager.Instance.PlaySFX("change_screen");
        _orangeActive = !_orangeActive;
        mainTilemap.Swap(_orangeActive);
        spikeTilemap.Swap(_orangeActive);
        ChangeBackground(BgImg, _orangeActive);
    }
    
    #endregion

    #region PrivateMethods

    private void ApplySettings()
    {
        //Set Volume of the game
        float volume = PlayerPrefs.GetFloat("volume", 0.5f);
        AudioManager.Instance.SoundVolume(volume);
    }
    
    private void UpdateVictoryUI()
    {
        victoryLevelName.text = "Level " + _currentLevel + ": " + levels[_currentLevel].scene.SceneName + " Completed!";
        int minTouches = levels[_currentLevel].GetMinimumTouches();
        if(minTouches == 0)
        {
            victoryMinTouches.text = "Min Touches: N/A";
        }
        else
        {
            victoryMinTouches.text = "Min Touches: " + minTouches;
        }
        if(_touches < minTouches || minTouches == 0)
        {
            recordImage.SetActive(true);
        }
        else if(_touches > minTouches)
        {
            recordImage.SetActive(false);
        }
        victoryTouches.text = "Touches: " + _touches;
    }
    private void SetTouchText()
    {
        touchText.text = "Touches: " + _touches;
    }
    
    private void ChangeBackground(RawImage img, bool orangeActive)
    {
        if (orangeActive)
        {
            img.CrossFadeAlpha(0, 0.2f, false);
        }
        else
        {
            img.CrossFadeAlpha(1, 0.2f, false);
        }
    }
    #endregion
}

