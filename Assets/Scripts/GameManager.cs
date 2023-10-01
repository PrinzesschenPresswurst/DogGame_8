using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    private int _currentScene;
    private int _maxScenes;
    
    private void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        _maxScenes = SceneManager.sceneCountInBuildSettings;
    }

    public void Death()
    {
        gameOverCanvas.gameObject.SetActive(true);
        Invoke("ReloadScene", 2f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(_currentScene);
    }

    public void OnExitReached()
    {
        Invoke("LoadNextLevel", 2f);
    }

    private void LoadNextLevel()
    {
        int nextScene = _currentScene + 1;
        if (nextScene < _maxScenes)
        {
            SceneManager.LoadScene(nextScene);
        }

        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
