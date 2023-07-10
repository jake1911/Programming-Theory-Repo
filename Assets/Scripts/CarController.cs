using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Car car;
   
    
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<Car>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RightButton()
    {
        car.Right();
    }
    public void LeftButton()
    {
        car.Left();
    }
    
}
