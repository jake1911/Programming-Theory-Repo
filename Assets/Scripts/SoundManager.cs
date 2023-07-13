using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _crash, _coin, _gameOver;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>(); 
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Crash()
    {
        _audioSource.PlayOneShot(_crash, 0.5f);
    }
    public void Coin()
    {
        _audioSource.PlayOneShot(_coin);
    }
    public void GameOver() 
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_gameOver);
    }
}
