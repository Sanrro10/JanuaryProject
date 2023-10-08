using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DevLocker.Utils;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    private const string UNLOCKED_KEY_PREFIX = "LevelUnlocked_";
    private const string TOUCHES_KEY_PREFIX = "LevelTouches_";
    private const string COLLECTIBLES_KEY_PREFIX = "LevelCollectibles_";

    public SceneReference scene;
    [SerializeField] private int difficulty;
    [SerializeField] private float timeLimit;

    private int _touches;
    private int _collectibles;
    [SerializeField] private int totalCollectibles;
    [SerializeField] private bool unlocked;

    public void LoadLevel()
    {
        AudioManager.Instance.musicSource.Stop();
        SceneManager.LoadScene(scene.ScenePath);
    }

    public void SetTouches(int touches)
    {
        _touches = touches;
        PlayerPrefs.SetInt(TOUCHES_KEY_PREFIX + scene.ScenePath, _touches);
    }

    public int GetTimer()
    {
        return PlayerPrefs.GetInt(TOUCHES_KEY_PREFIX + scene.ScenePath, _touches);
    }

    public void SetUnlocked(bool unlockedVar)
    {
        this.unlocked = unlockedVar;
        PlayerPrefs.SetInt(UNLOCKED_KEY_PREFIX + scene.ScenePath, unlocked ? 1 : 0);
    }

    public bool IsUnlocked()
    {
        return PlayerPrefs.GetInt(UNLOCKED_KEY_PREFIX + scene.ScenePath, unlocked ? 1 : 0) == 1;
    }

    public void SetCollectibles(int collectibles)
    {
        _collectibles = collectibles;
        PlayerPrefs.SetInt(COLLECTIBLES_KEY_PREFIX + scene.ScenePath, _collectibles);
    }

    public int GetCollectibles()
    {
        return PlayerPrefs.GetInt(COLLECTIBLES_KEY_PREFIX + scene.ScenePath, _collectibles);
    }
    
    public int GetMinimumTouches()
    {
        return PlayerPrefs.GetInt(TOUCHES_KEY_PREFIX + scene.ScenePath, _touches);
    }
    public int GetDifficulty() => difficulty;
}

