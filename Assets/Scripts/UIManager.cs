using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText, _highScore, _currentLevel;
    public int _level;


    // Start is called before the first frame update
    void Start()
    {
        _level = 1;
        _scoreText.text = "Score: " + 0;
        UpdateHighScore();
        _currentLevel.text = "Level: " + _level;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
