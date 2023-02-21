using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] List<Level> levels = new List<Level>();
    private static int currentLevel = 0;
    private int lastUnlockedLevel = 0;
    public GameObject MainMenu;
    public GameObject LevelSelectMenu;
    public GameObject OptionsMenu;
    public GameObject ExitConfirmation;
    public Button LeftArrow;
    public Button RightArrow;
    public Button SelectLevelButton;
    public TextMeshProUGUI LevelName;
    public TextMeshProUGUI LevelDifficulty;
    public TextMeshProUGUI LevelScore;
    public TextMeshProUGUI LevelTimeLimitText;
    public OptionsMenu optionsM;

    
    public void ReturnButton()
    {
        AudioManager.Instance.PlaySFX("button");
        MainMenu.SetActive(true);
        LevelSelectMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    } 
    private void SetLastUnlockedLevel()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].IsUnlocked())
            {
                lastUnlockedLevel = i;
            }else{
                break;
            }
        }
    }
    public void ShowOptionsMenu()
    {
        AudioManager.Instance.PlaySFX("button");
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void ShowLevelSelectMenu()
    {
        AudioManager.Instance.PlaySFX("button");
        if (currentLevel == 0)
        {
            LeftArrow.gameObject.SetActive(false);
        }else if(currentLevel == levels.Count -1)
        {
            RightArrow.gameObject.SetActive(false);
        }
        UpdateLevelSelectMenu();
        MainMenu.SetActive(false);
        LevelSelectMenu.SetActive(true);
    }
    private void UpdateLevelSelectMenu(){
        LevelName.text = levels[currentLevel].scene.SceneName;
        LevelDifficulty.text = "Difficulty: "+ levels[currentLevel].GetDifficulty().ToString() + "/5";
        LevelTimeLimitText.text = "Time Limit: " + levels[currentLevel].GetTimeLimit().ToString();
        LevelScore.text = "Time: " + levels[currentLevel].GetTimer().ToString();
        if(levels[currentLevel].IsUnlocked())
        {
            SelectLevelButton.gameObject.SetActive(true);
        }else{
            SelectLevelButton.gameObject.SetActive(false);
        }
    }
    public void NextLevel()
    {
        AudioManager.Instance.PlaySFX("button");
        if (currentLevel < levels.Count -1)
        {
            currentLevel++;
            LeftArrow.gameObject.SetActive(true);
            if(currentLevel == levels.Count -1)
            {
                RightArrow.gameObject.SetActive(false);
            }
            UpdateLevelSelectMenu();
        }
    }
    public void PreviousLevel()
    {
        AudioManager.Instance.PlaySFX("button");
        if (currentLevel > 0)
        {
            currentLevel--;
            RightArrow.gameObject.SetActive(true);
            if(currentLevel == 0)
            {
                LeftArrow.gameObject.SetActive(false);
            }
            UpdateLevelSelectMenu();
        }
    }
    public void LoadCurrentLevel()
    {
        //Si descomento esta linea de codigo el nivel no carga lol
        //AudioManager.Instance.PlaySFX("button_start_level");
        Debug.Log("voy a cargar un nivel");
        AudioManager.Instance.PlaySFX("button_start");
        levels[currentLevel].LoadLevel();
    }
    public void OpenExitConfirmation()
    {
        ExitConfirmation.SetActive(true);
        MainMenu.SetActive(false);
        Application.Quit();
    }
    public void CloseExitConfirmation()
    {
        ExitConfirmation.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void ExitFromApp()
    {
        AudioManager.Instance.PlaySFX("button");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        optionsM.Inizialice();
        SetLastUnlockedLevel();
        currentLevel = lastUnlockedLevel;
        MainMenu.SetActive(true);
        LevelSelectMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }
    
}
