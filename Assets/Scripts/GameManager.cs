using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Настройки загрузки")]
    [SerializeField] private bool loadLastSavedLevel = true;
    [SerializeField] private int defaultLevelIndex = 0; // Индекс первого уровня (Level_1)
    
    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Загружаем последний сохраненный уровень при первом запуске
            if (loadLastSavedLevel)
            {
                LoadLastSavedLevel();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// Загружает последний сохраненный уровень
    /// </summary>
    public void LoadLastSavedLevel()
    {
        // Получаем индекс последнего сохраненного уровня
        int lastLevel = PlayerPrefs.GetInt("CurrentLevel", defaultLevelIndex);
        
        // Проверяем, что индекс уровня валиден
        if (lastLevel >= 0 && lastLevel < SceneManager.sceneCountInBuildSettings)
        {
            // Если мы не на нужном уровне, загружаем его
            if (SceneManager.GetActiveScene().buildIndex != lastLevel)
            {
                SceneManager.LoadScene(lastLevel);
            }
        }
        else
        {
            // Если индекс невалиден, загружаем первый уровень
            SceneManager.LoadScene(defaultLevelIndex);
        }
    }
    
    /// <summary>
    /// Сохраняет текущий уровень
    /// </summary>
    public void SaveCurrentLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }
    
    /// <summary>
    /// Сбрасывает прогресс и возвращает к первому уровню
    /// </summary>
    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("CurrentLevel");
        PlayerPrefs.DeleteKey("LastCompletedLevel");
        PlayerPrefs.DeleteKey("CheackPoint");
        PlayerPrefs.Save();
        
        SceneManager.LoadScene(defaultLevelIndex);
    }
    
    /// <summary>
    /// Загружает конкретный уровень по индексу
    /// </summary>
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SaveCurrentLevel();
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.LogWarning($"Попытка загрузить несуществующий уровень: {levelIndex}");
        }
    }
    
    /// <summary>
    /// Загружает следующий уровень
    /// </summary>
    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;
        
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            Debug.Log("Это последний уровень!");
            // Можно добавить логику для завершения игры
        }
    }
    
    /// <summary>
    /// Загружает предыдущий уровень
    /// </summary>
    public void LoadPreviousLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int previousLevel = currentLevel - 1;
        
        if (previousLevel >= 0)
        {
            LoadLevel(previousLevel);
        }
        else
        {
            Debug.Log("Это первый уровень!");
        }
    }
    
    /// <summary>
    /// Получает индекс текущего уровня
    /// </summary>
    public int GetCurrentLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    
    /// <summary>
    /// Получает индекс последнего сохраненного уровня
    /// </summary>
    public int GetLastSavedLevelIndex()
    {
        return PlayerPrefs.GetInt("CurrentLevel", defaultLevelIndex);
    }
}
