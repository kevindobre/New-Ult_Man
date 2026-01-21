using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D Myrigidbody;
    [Header("Speed Setup")]
    public float speed;
    public float speedRun;
    public float _currentSpeed;
    public bool _isRunning = false;
    public float forcejump = 5;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

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
            Myrigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(Myrigidbody.transform);

            HandleScaleJump();
        }
    }
    private void HandleScaleJump()
    {
        Myrigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        Myrigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
