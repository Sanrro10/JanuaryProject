using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DevLocker.Utils;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    private const string UNLOCKED_KEY_PREFIX = "LevelUnlocked_";
    private const string TIMER_KEY_PREFIX = "LevelTimer_";
    private const string COLLECTIBLES_KEY_PREFIX = "LevelCollectibles_";

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
        PlayerPrefs.SetFloat(TIMER_KEY_PREFIX + scene.ScenePath, timer);
    }

    public float GetTimer()
    {
        return PlayerPrefs.GetFloat(TIMER_KEY_PREFIX + scene.ScenePath, timer);
    }

    public void SetUnlocked(bool unlocked)
    {
        this.unlocked = unlocked;
        PlayerPrefs.SetInt(UNLOCKED_KEY_PREFIX + scene.ScenePath, unlocked ? 1 : 0);
    }

    public bool IsUnlocked()
    {
        return PlayerPrefs.GetInt(UNLOCKED_KEY_PREFIX + scene.ScenePath, unlocked ? 1 : 0) == 1;
    }

    public void SetCollectibles(int collectibles)
    {
        this.collectibles = collectibles;
        PlayerPrefs.SetInt(COLLECTIBLES_KEY_PREFIX + scene.ScenePath, collectibles);
    }

    public int GetCollectibles()
    {
        return PlayerPrefs.GetInt(COLLECTIBLES_KEY_PREFIX + scene.ScenePath, collectibles);
    }

    public float GetTimeLimit() => timeLimit;
    public int GetDifficulty() => difficulty;
}

