using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Настройки загрузки")]
    [SerializeField] private int defaultLevelIndex = 0; // Индекс первого уровня (Level_1)

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

    public void SaveCurrentLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.DeleteKey("LastCompletedLevel");
        PlayerPrefs.SetFloat("CheackPoint", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(1);
    }

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
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
