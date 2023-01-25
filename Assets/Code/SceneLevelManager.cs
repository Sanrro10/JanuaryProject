using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLevelManager : MonoBehaviour
{
    public static SceneLevelManager instance;

    public int currentLevel = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }
    public void ReloadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }
    public void LoadLevel(int level)
    {
        currentLevel = level;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }
    public void LoadMainMenu()
    {
        currentLevel = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }
}
