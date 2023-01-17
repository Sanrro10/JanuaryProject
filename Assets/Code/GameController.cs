using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;
    public GameObject of;
    public GameObject bf;

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
    // Start is called before the first frame update
    void Start()
    {
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
