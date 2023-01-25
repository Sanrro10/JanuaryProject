using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DevLocker.Utils;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    public SceneReference scene;
    public int difficulty;
    private int score;
    [SerializeField] private bool unlocked;
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(scene.ScenePath);
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetUnlocked(bool unlocked)
    {
        this.unlocked = unlocked;
    }
    public bool IsUnlocked()
    {
        return unlocked;
    }
}
