using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TilemapSwitch orangeTilemap;
    [SerializeField] private TilemapSwitch blueTilemap;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private List<Tile> spikeTiles;

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
        Reload();
        //Pause();
        //UI de muerte y reinicio
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    }
    public List<Tile> GetSpikeTiles(){
        return spikeTiles;
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
