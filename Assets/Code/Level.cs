using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DevLocker.Utils;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    public SceneReference scene;
    [SerializeField] private int difficulty;
    [SerializeField] private float timeLimit;
    private float timer;
    private int collectibles;
    [SerializeField] private int totalCollectibles;
    [SerializeField] private bool unlocked;
    
    public void LoadLevel()
    {
        AudioManager.Instance.musicSource.Stop();
        SceneManager.LoadScene(scene.ScenePath);
    }
    public void SetTimer(float timer)
    {
        this.timer = timer;
    }
    public float GetTimer()
    {
        return timer;
    }
    public void SetUnlocked(bool unlocked)
    {
        this.unlocked = unlocked;
    }
    public bool IsUnlocked()
    {
        return unlocked;
    }
    public void SetCollectibles(int collectibles)
    {
        this.collectibles = collectibles;
    }
    public int GetCollectibles()
    {
        return collectibles;
    }
    public float GetTimeLimit()
    {
        return timeLimit;
    }
    public int GetDifficulty()
    {
        return difficulty;
    }
    
}
