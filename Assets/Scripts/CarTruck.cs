using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTruck : Car
{
    public new void Awake()
    {
        LoadCar();
        selectedCar = PlayerPrefs.GetInt("SelectedCar");
    }
    void Start()
    {
        selectedCar = PlayerPrefs.GetInt("SelectedCar");
        LoadCar();
        _anim = GetComponent<Animator>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _roadMovement = GameObject.Find("Road").GetComponent<RoadMovement>();
        _mainMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();

        _isLeft = true;
        _isRight = false;
        _lives = 2f;
        _multiplier = 2f;
        _life3.SetActive(false);
    }
}
