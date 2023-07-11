using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Car car;
    private CarTank _carTank;
    private CarTruck _carTruck;
   
    
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<Car>();
        _carTank = GameObject.Find("Car").GetComponent<CarTank>();
        _carTruck = GameObject.Find("Car").GetComponent< CarTruck>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RightButton()
    {
        car.Right();
        _carTank.Right();
        _carTruck.Right();
    }
    public void LeftButton()
    {
        car.Left();
        _carTank.Left();
        _carTruck.Left();
    }
    
}
