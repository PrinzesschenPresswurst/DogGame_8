using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    private int _currentScene;
    
    private void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        _currentScene = SceneManager.GetActiveScene().buildIndex;
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
}
