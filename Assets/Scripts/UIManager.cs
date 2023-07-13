using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText, _highScore, _currentLevel;
    public int carNumber;
    public int _level;
    [SerializeField]
    private GameObject _hatchback, _tank, _truck;
    [SerializeField]
    private GameObject _gameOverPanel, _gameOverText, _pauseText, _resume, _restart, _mainMenu;
    void Start()
    {
        _level = 1;
        _scoreText.text = "Score: " + 0;
        UpdateHighScore();
        CheckCar();
        LoadCar();
        _currentLevel.text = "Level: " + _level;
    }
    public void UpdateScore(float points)
    {
        _scoreText.text = "Score: " + points.ToString();
    }
    public void UpdateLevel()
    {
        _level++;
        _currentLevel.text = "Level: " + _level.ToString();
    }
    public void UpdateHighScore()
    {
        _highScore.text = $"High Score: {PlayerPrefs.GetFloat("HighScore", 0)}";
    }
    public void CheckCar()
    {
        carNumber = PlayerPrefs.GetInt("SelectedCar");
    }
    public void LoadCar()
    {
        if (carNumber == 1)
        {
            _hatchback.SetActive(true);
        }
        else if (carNumber == 2)
        {
            _tank.SetActive(true);
        }
        else if (carNumber == 3)
        {
            _truck.SetActive(true);
        }
    }
    public void GameOver()
    {
        OpenGameOverPanel();
        _gameOverText.SetActive(true);  
    }
    public void Pause()
    {
        OpenGameOverPanel();
        _pauseText.SetActive(true);
        _resume.SetActive(true);    

        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        CloseGameOverPanel();
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
    private void CloseGameOverPanel()
    {
        _gameOverPanel.SetActive(false);
        _pauseText.SetActive(false);
        _gameOverText.SetActive(false);
        _resume.SetActive(false);
        _restart.SetActive(false);
        _mainMenu.SetActive(false);
    }
    public void OpenGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
        _restart.SetActive(true);
        _mainMenu.SetActive(true);
    }
}
