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
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private GameObject nextlevelButton;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseOptionsPanel;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button switchButton;
    public OptionsMenu optionsM;


    //Background
    [SerializeField] private RawImage BgImg;

    private bool orangeActive;

    private bool running;

    private int currentLevel = 0;
    private int collectibles;

    //Countdown
    private int countdownMax = 3;
    private float countdownTime = 0;
    private bool resumeGame = false;

    public bool GetResumeGame()
    {
        return resumeGame;
    }

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
        levels[currentLevel].SetTimer(AudioManager.Instance.GetTimer());
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
    public void DieByTimer()
    {
        AudioManager.Instance.PlaySFX("player_death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.Instance.musicSource.Stop();
        running = false;
        Time.timeScale = 0;
        UpdateVictoryUI();
        victoryUI.SetActive(true);
        gameUI.SetActive(false);
    }
    public void Pause()
    {
        countdownTime = countdownMax;
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
        resumeGame = true;
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
        AudioManager.Instance.SetTimer(levels[currentLevel].GetTimeLimit());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextlevel()
    {
        Debug.Log("AAAAAAAAAAAAAAAA");
        AudioManager.Instance.PlaySFX("button_start_level");
        Time.timeScale = 1;
        levels[currentLevel + 1].LoadLevel();

    }
    private void UpdateVictoryUI()
    {
        victoryLevelName.text = "Level " + currentLevel + ":" + levels[currentLevel].name + " Completed!";
        victoryTimer.text = "Time: " + AudioManager.Instance.GetTimer().ToString("F2") + "s";
        victoryCollectibles.text = "Collectibles: " + collectibles + "/" + levels[currentLevel].GetCollectibles();
    }
    private void UpdateDefeatUI()
    {
        victoryLevelName.text = "Level " + currentLevel + ":" + levels[currentLevel].name + " Failed!";
        victoryTimer.text.Remove(0);
        victoryCollectibles.text.Remove(0);
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
        AudioManager.Instance.SelectMusic();
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
        if (AudioManager.Instance.GetTimer() <= 0)
        {
            AudioManager.Instance.SetTimer(levels[currentLevel].GetTimeLimit());
        }
        countdownTime = countdownMax;
        resumeGame = true;
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
        AudioManager.Instance.UpdateTimer();
        if (AudioManager.Instance.GetTimer() <= 0)
        {
            DieByTimer();
        }
        timerText.text = "Time: " + AudioManager.Instance.GetTimer().ToString("F0") + "s";

        //full window editor
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
        //}

        if (resumeGame)
        {
            player.GetPlayerRigidbody().constraints = RigidbodyConstraints2D.FreezePosition;
            jumpButton.enabled = false;
            switchButton.enabled = false;
            countdownText.text = countdownTime.ToString("F0");
            countdownTime -= Time.deltaTime;
            if(countdownTime <= 0)
            {
                player.GetPlayerRigidbody().constraints = RigidbodyConstraints2D.None;
                jumpButton.enabled = true;
                switchButton.enabled = true;
                countdownTime = 3;
                countdownText.text = "";
                resumeGame = false;
            }
        }
    }
}
