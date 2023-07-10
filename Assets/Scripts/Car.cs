using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private Animator _anim;
    private bool _isLeft;
    private bool _isRight;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _isLeft = true;
        _isRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CarMovement()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.right);
    }
    public void Right()
    {
        if(_isLeft == true)
        {
            _anim.SetTrigger("Move_r");
            _isLeft = false;
            _isRight = true;
        }
    }
    public void Left()
    {
        if(_isRight == true) 
        {
            _anim.SetTrigger("Move_l");
            _isLeft = true;
            _isRight = false;
        }
    }
}
