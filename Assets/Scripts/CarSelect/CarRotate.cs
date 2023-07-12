using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotate : MonoBehaviour
{
    private int _rotateSpeed = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotateSpeed * Time.deltaTime * Vector3.up);
    }
}
