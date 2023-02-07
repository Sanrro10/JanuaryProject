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
        SceneLevelManager.ReloadLevel();
        AudioManager.Instance.PlaySFX("player_death");
        //Pause();
        //UI de muerte y reinicio
    }
    public void Win()
    {
        Pause();
        AudioManager.Instance.PlaySFX("goal");
        AudioManager.Instance.musicSource.Stop();
        //UI de victoria y siguiente nivel
    }
    public void Pause()
    {
        running = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        running = true;
        Time.timeScale = 1;
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
        SceneLevelManager.SetCurrentLevel(SceneManager.GetActiveScene().buildIndex);
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
