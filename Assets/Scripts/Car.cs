using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float _speed = 5f,
                  _score = 0f,
                  _multiplier,
                  _lives = 10;
    public GameObject _life1, _life2, _life3;

    public Animator _anim;
    public UIManager _uiManager;
    public SpawnManager _spawnManager;
    public ObstacleMovement _obstacleMovement;
    public RoadMovement _roadMovement;
    public SoundManager _soundManager;
    public bool _isLeft;
    public bool _isRight;

    public GameObject dirtTracks;

    public ParticleSystem _explosion, _coinPop;
    public bool useUnscaledTime = false;

    public MainMenu _mainMenu;

    void Start()
    {

        _anim = GetComponent<Animator>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _roadMovement = GameObject.Find("Road").GetComponent<RoadMovement>();
        _mainMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();
        

        _isLeft = true;
        _isRight = false;
        _lives = 1f;
        _life3.SetActive(false);
        _life2.SetActive(false);
        _multiplier = 2f;
    }
    void Update()
    {
        
    }
    public void CarMovement()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.right);
    }
    public virtual void Right()
    {
        if(_isLeft == true)
        {
            _anim.SetTrigger("Move_r");
            _isLeft = false;
            _isRight = true;
        }
    }
    public virtual void Left()
    {
        if(_isRight == true) 
        {
            _anim.SetTrigger("Move_l");
            _isLeft = true;
            _isRight = false;
        }
    }
    public virtual void AddScore(float point)
    {
        if(_multiplier == 1f)
        {
            float points = _multiplier * point;
            _score += points;
            IncreaseSpeed();
            _uiManager.UpdateScore(_score);
        }
        else if(_multiplier == 2f)
        {
            float points = _multiplier * point;
            _score += points;
            IncreaseSpeed();
            _uiManager.UpdateScore(_score);
        }
        CheckHighScore();
    }
    void CheckHighScore()
    {
        if (_score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            
            PlayerPrefs.SetFloat("HighScore", _score);
            _uiManager.UpdateHighScore();
        }
    }
    public void IncreaseSpeed()
    {
        if ((_score % 100f == 0) && (_score < 400f))
        {           
            _spawnManager.RaiseDifficulty();
            _roadMovement.IncreaseScrollSpeed();
            _uiManager.UpdateLevel();
        }
    }
    public virtual void Lives()
    {
        _lives--;
        if (_lives == 2)
        {
            _life3.SetActive(false);
        }
        if(_lives == 1)
        {
            _life2.SetActive(false);
        }
        if (_lives == 0)
        {
            _soundManager.GameOver();
            _life1.SetActive(false);
            _uiManager.GameOver();
            _spawnManager.OnPlayerDeath();
            _roadMovement.OnPlayerDeath();
            dirtTracks.SetActive(false);
        }
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        _soundManager.Crash();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (Time.timeScale < 0.01f)
            {
                _explosion.Simulate(Time.unscaledDeltaTime, true, false);
                var exp = Instantiate(_explosion, transform.position + new Vector3(0, 0, 4), _explosion.transform.rotation);
                _explosion.Play();
                Destroy(exp.gameObject, 2f);
            }
            var ex = Instantiate(_explosion, transform.position + new Vector3(0,0,4), _explosion.transform.rotation);
            _explosion.Play();
            Destroy(ex.gameObject, 2f);
        }
        else if (other.CompareTag("Coin"))
        {
            _soundManager.Coin();
            float x = transform.position.x;
            var ex = Instantiate(_coinPop, new Vector3(x,2,16), _coinPop.transform.rotation);
            _coinPop.Play();
            Destroy(ex.gameObject, 1f);           
        }
    }
}
