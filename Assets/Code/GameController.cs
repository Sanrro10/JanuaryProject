using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public Player player;
    public TilemapSwitch orangeTilemap;
    public TilemapSwitch blueTilemap;

    private bool orangeActive;

    private bool running;

    public bool isRunning(){
        return running;
    }

    public Player getPlayer(){
        return player;
    }
    public void Die(){
        Pause();
        //UI de muerte y reinicio
    }
    public void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause(){
        running = false;
        Time.timeScale = 0;
    }
    public void Resume(){
        running = true;
        Time.timeScale = 1;
    }
    public void swapTilemaps(){
        orangeActive = !orangeActive;
        orangeTilemap.Swap(orangeActive);
        blueTilemap.Swap(!orangeActive);
    }
    // Start is called before the first frame update
    void Start()
    {
        running = true;
        orangeActive = false;
        orangeTilemap.Swap(orangeActive);
        blueTilemap.Swap(!orangeActive);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
