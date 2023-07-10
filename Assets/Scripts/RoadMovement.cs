using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField]
    private float _scrollSpeed = 10f;

    private Vector3 _startPosition;
    private float _repeatWidth;
    private bool _stopScrolling = false;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x * 5;
        StartCoroutine(Repeat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveDown()
    {
        transform.Translate(_scrollSpeed * Time.deltaTime * Vector3.right);
    }
    public void RepeatBackground()
    {
        if (transform.position.z < _startPosition.z - _repeatWidth)
        {
            transform .position = _startPosition;
        }
    }
    IEnumerator Repeat()
    {
        while(_stopScrolling == false) 
        {
        MoveDown();
        RepeatBackground();
        yield return null;  
        }
    }
    public void OnPlayerDeath()
    {
        _stopScrolling = true;
    }
}

