using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTank : Car
{
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _roadMovement = GameObject.Find("Road").GetComponent<RoadMovement>();

        _isLeft = true;
        _isRight = false;
        _lives = 3f;
        _multiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
