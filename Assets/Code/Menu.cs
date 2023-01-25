using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] List<Level> levels = new List<Level>();
    private int currentLevel = 0;
    private int lastUnlockedLevel = 0;
    public GameObject MainMenu;
    public GameObject LevelSelectMenu;
    public Button LeftArrow;
    public Button RightArrow;
    public TextMeshProUGUI LevelName;
    public TextMeshProUGUI LevelDifficulty;
    public TextMeshProUGUI LevelScore;

    public void ReturnButton()
    {
        MainMenu.SetActive(true);
        LevelSelectMenu.SetActive(false);
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
    public void ShowLevelSelectMenu()
    {
        if(currentLevel == 0)
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
        LevelDifficulty.text = "Difficulty: "+ levels[currentLevel].difficulty.ToString() + "/5";
        LevelScore.text = "Score: " + levels[currentLevel].GetScore().ToString();
    }
    public void NextLevel()
    {
        if(currentLevel < levels.Count -1)
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
        if(currentLevel > 0)
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
        levels[currentLevel].LoadLevel();
    }
    public void Exit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetLastUnlockedLevel();
        currentLevel = lastUnlockedLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
