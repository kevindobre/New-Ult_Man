using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Myrigidbody;
    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;
    public float speedRun;

    public float forcejump = 5;

    public float _currentSpeed;

    public bool _isRunning = false;

    private void Update()
    {
        Handlejump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else 
        _currentSpeed = speed;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Myrigidbody.velocity = new Vector2(-_currentSpeed, Myrigidbody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Myrigidbody.velocity = new Vector2(_currentSpeed, Myrigidbody.velocity.y);
        }


        if(Myrigidbody.velocity.x > 0)
        {
            Myrigidbody.velocity += friction;
        }
        else if (Myrigidbody.velocity.x < 0)
        {
            Myrigidbody.velocity -= friction;
        }
    }

    private void Handlejump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Myrigidbody.velocity = Vector2.up * forcejump;
        }
    }
}
