using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove35 : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem _explosion;
    public float _speed = 40f;
    public Car _car;
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
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
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
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _car.Lives();
            if (Time.timeScale < 0.01f)
            {
                _explosion.Simulate(Time.unscaledDeltaTime, true, false);
                var exp = Instantiate(_explosion, transform.position + new Vector3(0, 0, 4), _explosion.transform.rotation);
                _explosion.Play();
                Destroy(exp.gameObject, 2f);
            }
            var ex = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(ex, 1f);
            Destroy(gameObject);
        }
    }
}
