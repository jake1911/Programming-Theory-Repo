using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
    public void MoveDown()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.back);
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
}
