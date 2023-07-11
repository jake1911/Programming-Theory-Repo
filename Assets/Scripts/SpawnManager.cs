using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _obstaclePrefabs,
                         _obstaclePrefabs35,
                         _obstaclePrefabs50,
                         _obstaclePrefabs75;
    [SerializeField]
    private GameObject _coin, _coin35, _coin50, _coin75;
    private int _obstacleCount;
    [SerializeField]
    private int _level = 1;
    [SerializeField]
    private int _randomN;

    [SerializeField]
    private float _startDelay = 3f,
                  _xSpawnPosition,
                  _spawnRate;

    private Vector3 _spawnPosition = new (0,0,0);
    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        _spawnRate = 2.15f;
        _xSpawnPosition = 5f;
        _spawnPosition = new(_xSpawnPosition,0,0);
        StartCoroutine(SpawnObstacle());
        
    }

    // Update is called once per frame
    void Update()
    {
        _obstacleCount = Random.Range(0, _obstaclePrefabs.Length);
    }
    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(_startDelay);
        while (_stopSpawning == false)
        {
            _randomN = Random.Range(1, 3);
            if (_randomN == 1)
            {     
                Position();
                yield return new WaitForSeconds(_spawnRate);
            }
            else if ( _randomN == 2)
            {  
                Position();
                yield return new WaitForSeconds(_spawnRate);
            }
        }
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
        Time.timeScale = 0;
    }
    public void RaiseDifficulty()
    {
        _spawnRate -= 0.5f;
        if( _level < 4)
        {
            _level++;
        }
        else
        {
            _level += 0;
        }
    }
    public void Position()
    {
        var w = _obstaclePrefabs[_obstacleCount];
        var x = _obstaclePrefabs35[_obstacleCount];
        var y = _obstaclePrefabs50[_obstacleCount];
        var z = _obstaclePrefabs75[_obstacleCount];

        if (_level == 1)
        {       
            if (_randomN == 1) 
            {
                Instantiate(w, new(_xSpawnPosition, 0, 85f), w.transform.rotation);
                Instantiate(_coin, new(-_xSpawnPosition, 1.15f, 85f), _coin.transform.rotation);
            }
            else if (_randomN == 2)
            {
                Instantiate(w, new(-_xSpawnPosition, 0, 85f), w.transform.rotation);
                Instantiate(_coin, new(_xSpawnPosition, 1.15f, 85f), _coin.transform.rotation);
            }
        }
        if (_level == 2)
        {       
            if (_randomN == 1)
            {
                Instantiate(x, new(_xSpawnPosition, 0.05f, 105f), x.transform.rotation);
                Instantiate(_coin35, new(-_xSpawnPosition, 1.15f, 105f), _coin35.transform.rotation);
            }
            else if (_randomN == 2)
            {
                Instantiate(x, new(-_xSpawnPosition, 0.05f, 105f), x.transform.rotation);
                Instantiate(_coin35, new(_xSpawnPosition, 1.15f, 105f), _coin35.transform.rotation);
            }
        }
        if (_level == 3)
        {          
            if (_randomN == 1)
            {
                Instantiate(y, new(_xSpawnPosition, 0.05f, 105f), y.transform.rotation);
                Instantiate(_coin50, new(-_xSpawnPosition, 1.15f, 105f), _coin50.transform.rotation);
            }
            else if (_randomN == 2)
            {
                Instantiate(y, new(-_xSpawnPosition, 0.05f, 105f), y.transform.rotation);
                Instantiate(_coin50, new(_xSpawnPosition, 1.15f, 105f), _coin50.transform.rotation);
            }
        }
        if (_level == 4)
        {
            
            if (_randomN == 1)
            {
                Instantiate(z, new(_xSpawnPosition, 0.05f, 105f), z.transform.rotation);
                Instantiate(_coin75, new(-_xSpawnPosition, 1.15f, 105f), _coin75.transform.rotation);
            }
            else if (_randomN == 2)
            {
                Instantiate(z, new(-_xSpawnPosition, 0.05f, 105f), z.transform.rotation);
                Instantiate(_coin75, new(_xSpawnPosition, 1.15f, 105f), _coin75.transform.rotation);
            }
        } 
    }
}
