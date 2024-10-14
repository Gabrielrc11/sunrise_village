using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;

    private bool _isRunning;
    private bool _isRolling;
    private float initialSpeed;
    private Rigidbody2D rig;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update() 
    {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void OnMove() 
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun() 
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            speed = runSpeed;
            _isRolling = true;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    #endregion

}
