using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _currentScene;
    void Start()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(_currentScene + 1);
    }
}
