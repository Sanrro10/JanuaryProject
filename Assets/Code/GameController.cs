using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TilemapSwitch spikeTilemap;
    [SerializeField] private TilemapSwitch mainTilemap;
    [SerializeField] private List<Tile> victoryTiles;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseOptionsPanel;


    //Background
    [SerializeField] private RawImage BgImg;

    private bool orangeActive;

    private bool running;

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
    public void Die()
    {
        AudioManager.Instance.PlaySFX("player_death");
        running = false;
        Time.timeScale = 0;
        deathUI.SetActive(true);
        //UI de muerte y reinicio
    }
    public void Win()
    {
        AudioManager.Instance.PlaySFX("goal");
        AudioManager.Instance.musicSource.Stop();
        running = false;
        Time.timeScale = 0;
        victoryUI.SetActive(true);
    }
    public void Pause()
    {
        running = false;
        Time.timeScale = 0;
        pauseOptionsPanel.SetActive(true);
        pauseUI.SetActive(true);
        gameUI.SetActive(false);

    }
    public void Resume()
    {
        running = true;
        Time.timeScale = 1;
        pauseOptionsPanel.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
    }
    public void ReturnFromOptions()
    {
        pauseUI.SetActive(true);
        optionsUI.SetActive(false);
    }
    public void ShowOptionsMenu()
    {
        pauseUI.SetActive(false);
        optionsUI.SetActive(true);
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void SwapTilemaps()
    {
        orangeActive = !orangeActive;
        mainTilemap.Swap(orangeActive);
        spikeTilemap.Swap(orangeActive);
        ChangeBackground(BgImg, orangeActive);
    }
    public List<Tile> GetVictoryTiles(){
        return victoryTiles;
    }

    void ChangeBackground(RawImage img, bool orangeActive) { 
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
        running = true;
        orangeActive = false;
        mainTilemap.Swap(orangeActive);
        spikeTilemap.Swap(orangeActive);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //player.Jump();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwapTilemaps();
        }

    }
    
}
