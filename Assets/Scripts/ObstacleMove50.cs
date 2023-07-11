using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove50 : ObstacleMove35
{

    //private Car _car;
    void Start()
    {
        _speed = 60f;
        _car = GameObject.Find("Car").GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _car.Lives();
            Destroy(gameObject);
        }
    } 
}
