using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject hatchback, hatchbackName, hatchbackStats,
                      truck, truckName, truckStats,
                      tank, tankName, tankStats;
    public AudioSource _audiosource;
    public bool isHatchbackActive,
                isTruckActive,
                isTankActive;
    [SerializeField]
    private int selectedCar;
    //private Car _car;

    void Start()
    {
        SelectHatchback();
        selectedCar = 1;
        _audiosource = GetComponent<AudioSource>();
        _audiosource.Play();
    }
    public void SaveCar()
    {
        PlayerPrefs.SetInt("SelectedCar", selectedCar);
    }
    public void LeftButton()
    {
        if(isHatchbackActive == true)
        {
            SelectTank();
            selectedCar++;
            SaveCar();
        }
        else if (isTankActive == true)
        {
            SelectTruck();
            selectedCar++;
            SaveCar();
        } 
        else if (isTruckActive == true)
        {
            SelectHatchback();
            selectedCar = 1;
            SaveCar();
        }
    }
    public void RightButton()
    {
        if (isHatchbackActive == true)
        {
            SelectTruck();
            selectedCar = 3;
            SaveCar();
        }
        else if (isTruckActive == true)
        {
            SelectTank();
            selectedCar--;
            SaveCar();
        }
        else if (isTankActive == true)
        {
            SelectHatchback();
            selectedCar--;
            SaveCar();
        }
    }
    private void SelectHatchback()
    {
        HatchStats();
        isHatchbackActive = true;
        hatchback.SetActive(true);
        isTruckActive = false;
        truck.SetActive(false);
        isTankActive = false;
        tank.SetActive(false);
    }
    private void SelectTruck()
    {
        TruckStats();
        isHatchbackActive = false;
        hatchback.SetActive(false);
        isTruckActive = true;
        truck.SetActive(true);
        isTankActive = false;
        tank.SetActive(false);
    }
    private void SelectTank()
    {
        TankStats();
        isHatchbackActive = false;
        hatchback.SetActive(false);
        isTruckActive = false;
        truck.SetActive(false);
        isTankActive = true;
        tank.SetActive(true);
    }
    private void HatchStats()
    {
        hatchbackName.SetActive(true);
        hatchbackStats.SetActive(true);
        truckName.SetActive(false);
        truckStats.SetActive(false);
        tankName.SetActive(false);
        tankStats.SetActive(false);
    }
    private void TruckStats()
    {
        hatchbackName.SetActive(false);
        hatchbackStats.SetActive(false);
        truckName.SetActive(true);
        truckStats.SetActive(true);
        tankName.SetActive(false);
        tankStats.SetActive(false);
    }
    private void TankStats()
    {
        hatchbackName.SetActive(false);
        hatchbackStats.SetActive(false);
        truckName.SetActive(false);
        truckStats.SetActive(false);
        tankName.SetActive(true);
        tankStats.SetActive(true);
    }
    public virtual void SelectCar()
    {
        SaveCar();
        SceneManager.LoadScene(2);  
    }

}
