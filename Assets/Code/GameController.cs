using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] List<Level> levels = new List<Level>();
    [SerializeField] private Player player;
    [SerializeField] private TilemapSwitch spikeTilemap;
    [SerializeField] private TilemapSwitch mainTilemap;
    [SerializeField] private Tilemap victoryTilemap;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private TextMeshProUGUI victoryLevelName;
    [SerializeField] private TextMeshProUGUI victoryTimer;
    [SerializeField] private TextMeshProUGUI victoryCollectibles;
    [SerializeField] private GameObject nextlevelButton;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseOptionsPanel;
    public OptionsMenu optionsM;


    //Background
    [SerializeField] private RawImage BgImg;

    private bool orangeActive;

    private bool running;

    private int currentLevel = 0;
    private float timer;
    private int collectibles;

    public bool IsRunning()
    {
        return running;
    }

    public Player GetPlayer()
    {
        return player;
    }
    public Tilemap GetMainTilemap()
    {
        return mainTilemap.GetTilemap();
    }
    public Tilemap GetSpikeTilemap()
    {
        return spikeTilemap.GetTilemap();
    }
    public Tilemap GetVictoryTilemap()
    {
        return victoryTilemap;
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
        running = false;
        Time.timeScale = 0;
        levels[currentLevel].SetTimer(timer);
        levels[currentLevel].SetCollectibles(collectibles);
        UpdateVictoryUI();
        if (currentLevel < levels.Count - 1)
        {
            levels[currentLevel + 1].SetUnlocked(true);
            nextlevelButton.SetActive(true);
        }
        victoryUI.SetActive(true);
        gameUI.SetActive(false);
    }
    public void Pause()
    {
        AudioManager.Instance.PlaySFX("button");
        AudioManager.Instance.musicSource.Pause();
        running = false;
        Time.timeScale = 0;
        pauseOptionsPanel.SetActive(true);
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
    }
    public void Resume()
    {
        AudioManager.Instance.PlaySFX("button");
        AudioManager.Instance.musicSource.Play();
        running = true;
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
        AudioManager.Instance.PlayMusic("menu_music");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextlevel()
    {
        Debug.Log("AAAAAAAAAAAAAAAA");
        AudioManager.Instance.PlaySFX("button_start_level");
        Time.timeScale = 1;
        levels[currentLevel+1].LoadLevel();
        
    }
    private void UpdateVictoryUI()
    {
        victoryLevelName.text = "Level " + currentLevel + ":" + levels[currentLevel].name + " Completed!";
        victoryTimer.text = "Time: " + timer.ToString("F2") + "s";
        victoryCollectibles.text = "Collectibles: " + collectibles + "/" + levels[currentLevel].GetCollectibles();
    }
    public void SwapTilemaps()
    {
        AudioManager.Instance.PlaySFX("change_screen");
        orangeActive = !orangeActive;
        mainTilemap.Swap(orangeActive);
        spikeTilemap.Swap(orangeActive);
        ChangeBackground(BgImg, orangeActive);
    }
    public void addCollectible()
    {
        collectibles++;
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



    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic("level_music_1");
        AudioManager.Instance.musicSource.Play();
        optionsM.Inizialice();
        running = true;
        orangeActive = false;
        mainTilemap.Swap(orangeActive);
        spikeTilemap.Swap(orangeActive);
        if (currentLevel == 0)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i].scene.SceneName == SceneManager.GetActiveScene().name)
                {
                    currentLevel = i;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //player.Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwapTilemaps();
        }
        timer += Time.deltaTime;

        //full window editor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
        }
    }

    
          
}
