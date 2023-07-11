using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f,
                  _pointValue = 5f;
    private Car _car;
    // Start is called before the first frame update
    void Start()
    {
        _car = GameObject.Find("Car").GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
    public void MoveDown()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
        DestroyOnZ();
    }
    public void DestroyOnZ()
    {
        float z = transform.position.z;
        if (z < 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _car.AddScore(_pointValue);
            Destroy(gameObject);
        }
    }
}
