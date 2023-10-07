using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Level variables
    [SerializeField] private List<Level> levels = new List<Level>();
    private static int currentLevel = 0;
    private int lastUnlockedLevel = 0;

    // Menu UI Elements
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject exitConfirmation;

    // Level UI Elements
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button rightArrow;
    [SerializeField] private Button selectLevelButton;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private TextMeshProUGUI levelDifficulty;
    [SerializeField] private TextMeshProUGUI levelScore;
    [SerializeField] private TextMeshProUGUI levelTimeLimitText;

    // Options Menu
    [SerializeField] private OptionsMenu optionsM;

    private void Start()
    {
        InitializeMenu();
    }

    public void ReturnButton()
    {
        PlayButtonClickSound();
        ShowMenu(mainMenu);
    }

    public void ShowOptionsMenu()
    {
        PlayButtonClickSound();
        ShowMenu(optionsMenu);
    }

    public void ShowLevelSelectMenu()
    {
        PlayButtonClickSound();
        UpdateArrowButtons();
        UpdateLevelSelectMenu();
        ShowMenu(levelSelectMenu);
    }

    public void NextLevel()
    {
        PlayButtonClickSound();
        if (currentLevel < levels.Count - 1)
        {
            currentLevel++;
            UpdateLevelSelectMenu();
            UpdateArrowButtons();
        }
    }

    public void PreviousLevel()
    {
        PlayButtonClickSound();
        if (currentLevel > 0)
        {
            currentLevel--;
            UpdateLevelSelectMenu();
            UpdateArrowButtons();
        }
    }

    public void LoadCurrentLevel()
    {
        AudioManager.Instance.PlaySFX("button_start");
        levels[currentLevel].LoadLevel();
    }

    public void OpenExitConfirmation()
    {
        ShowMenu(exitConfirmation);
    }

    public void CloseExitConfirmation()
    {
        ShowMenu(mainMenu);
    }

    public void ExitFromApp()
    {
        PlayButtonClickSound();
        Application.Quit();
    }

    private void PlayButtonClickSound()
    {
        AudioManager.Instance.PlaySFX("button");
    }

    private void InitializeMenu()
    {
        optionsM.Initialize();
        SetLastUnlockedLevel();
        currentLevel = lastUnlockedLevel;
        ShowMenu(mainMenu);
    }

    private void UpdateArrowButtons()
    {
        leftArrow.gameObject.SetActive(currentLevel != 0);
        rightArrow.gameObject.SetActive(currentLevel != levels.Count - 1);
    }

    private void UpdateLevelSelectMenu()
    {
        var level = levels[currentLevel];
        levelName.text = level.scene.SceneName;
        levelDifficulty.text = "Difficulty: " + level.GetDifficulty().ToString() + "/5";
        levelTimeLimitText.text = "Time Limit: " + level.GetTimeLimit().ToString();
        levelScore.text = "Time: " + level.GetTimer().ToString();
        selectLevelButton.gameObject.SetActive(level.IsUnlocked());
    }

    private void SetLastUnlockedLevel()
    {
        lastUnlockedLevel = levels.FindLastIndex(level => level.IsUnlocked());
    }

    private void ShowMenu(GameObject menu)
    {
        mainMenu.SetActive(menu == mainMenu);
        levelSelectMenu.SetActive(menu == levelSelectMenu);
        optionsMenu.SetActive(menu == optionsMenu);
        exitConfirmation.SetActive(menu == exitConfirmation);
    }
}
