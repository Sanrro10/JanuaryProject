using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TilemapSwitch orangeTilemap;
    [SerializeField] private TilemapSwitch blueTilemap;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private List<Tile> spikeTiles;
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
        return mainTilemap;
    }
    public Tilemap GetOrangeTilemap()
    {
        return orangeTilemap.GetTilemap();
    }
    public Tilemap GetBlueTilemap()
    {
        return blueTilemap.GetTilemap();
    }
    public void Die()
    {
        SceneLevelManager.instance.ReloadLevel();
        //Pause();
        //UI de muerte y reinicio
    }
    public void Win()
    {
        Pause();
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
        orangeTilemap.Swap(orangeActive);
        blueTilemap.Swap(!orangeActive);
        ChangeBackground(BgImg, orangeActive);
    }
    public List<Tile> GetSpikeTiles(){
        return spikeTiles;
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
        orangeTilemap.Swap(orangeActive);
        blueTilemap.Swap(!orangeActive);
    }
    void Awake()
    {
        spikeTiles.AddRange(orangeTilemap.GetSpikeTiles());
        spikeTiles.AddRange(blueTilemap.GetSpikeTiles());
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
