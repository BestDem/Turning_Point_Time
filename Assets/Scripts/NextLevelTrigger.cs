using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    [SerializeField] private int nextLevelIndex = 1; // Индекс следующего уровня

    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Сохраняем текущий уровень как последний пройденный
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LastCompletedLevel", currentSceneIndex);
            
            // Сохраняем следующий уровень как текущий
            PlayerPrefs.SetInt("CurrentLevel", nextLevelIndex);
            
            // Загружаем следующий уровень
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

    public void LoadLevelByIndex(int index)
    {
        // Сохраняем текущий уровень
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastCompletedLevel", currentSceneIndex);
        PlayerPrefs.SetInt("CurrentLevel", index);
        
        SceneManager.LoadScene(index);
    }
}