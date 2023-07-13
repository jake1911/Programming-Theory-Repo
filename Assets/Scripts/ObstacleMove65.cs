using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove65 : ObstacleMove35
{
    void Start()
    {
        _speed = 80f;
        _car = GameObject.Find("Car").GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
}
