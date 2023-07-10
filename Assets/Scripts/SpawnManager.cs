using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _obstaclePrefabs;
    private int _obstacleCount;
    [SerializeField]
    private int _randomN;

    [SerializeField]
    private float _startDelay = 3f,
                  _xSpawnPosition,
                  _spawnRate;

    private Vector3 _spawnPosition = new (0,0,0);
    private bool _stopSpawing = false;
    // Start is called before the first frame update
    void Start()
    {
        _spawnRate = 2f;
        _spawnPosition = new(_xSpawnPosition,0,85f);
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        _obstacleCount = Random.Range(0,_obstaclePrefabs.Length);
        
    }
    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(_startDelay);
        while (_stopSpawing == false)
        {
            _randomN = Random.Range(1, 3);
            if (_randomN == 1)
            {
                //_randomN = Random.Range(1, 3);
                _xSpawnPosition = 5f;
                Instantiate(_obstaclePrefabs[_obstacleCount], new(_xSpawnPosition, 0, 85f), _obstaclePrefabs[_obstacleCount].transform.rotation);
                yield return new WaitForSeconds(_spawnRate);
            }
            else if ( _randomN == 2)
            {
               // _randomN = Random.Range(1, 3);
                _xSpawnPosition = -5f;
                Instantiate(_obstaclePrefabs[_obstacleCount], new(_xSpawnPosition, 0, 85f), _obstaclePrefabs[_obstacleCount].transform.rotation);
                yield return new WaitForSeconds(_spawnRate);
            }
        }
    }
}
