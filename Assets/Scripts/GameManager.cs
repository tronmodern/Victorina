using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text levelText;
    public LevelData[] levels;
    public int currentLevelIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }


    public LevelData GetCurrentLevelData()
    {
        return levels[currentLevelIndex];
    }

    public void LoadNextLevel()
    {      
        currentLevelIndex++;
        if (currentLevelIndex >= levels.Length)
        {
            // Здесь можно обработать завершение игры
            SceneManager.LoadScene(0);
            currentLevelIndex = 0;
        }
        
    }
    public int GetCurrentLevelIndex()
    {
        return currentLevelIndex;
    }

    public void ResetLevel()
    {
        currentLevelIndex = 0;
    }


}
