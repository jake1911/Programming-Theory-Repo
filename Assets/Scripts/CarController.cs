using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private Car car;
    [SerializeField]
    private CarTank _carTank;
    [SerializeField]
    private CarTruck _carTruck;

    private int selectedCar;

    // Start is called before the first frame update
    private void Awake()
    {
        selectedCar = PlayerPrefs.GetInt("SelectedCar");
    }
    void Start()
    {
        if (selectedCar == 1) 
        {
        //car = GameObject.Find("Car").GetComponent<Car>();
        }
        else if (selectedCar == 2)
        {
        //_carTank = GameObject.Find("Car").GetComponent<CarTank>();
        }
        else if (selectedCar == 3)
        {
       // _carTruck = GameObject.Find("Car").GetComponent< CarTruck>();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void RightButton()
    {
        if (selectedCar == 1)
        {
            car.Right();
        }
        else if (selectedCar == 2)
        {
            _carTank.Right();
        }
        else if (selectedCar == 3)
        {
            _carTruck.Right();
        }
    }
    public void LeftButton()
    {
        if (selectedCar == 1)
        {
            car.Left();
        }
        else if (selectedCar == 2)
        {
            _carTank.Left();
        }
        else if (selectedCar == 3)
        {
            _carTruck.Left();
        }
    }
    
}
