using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [Header ("Shared")]
    [SerializeField] public Animator animator;
    public Vector2 _moveInput;
    public Rigidbody2D _rb;
    private PlayerJump _playerJump;
    private bool _isAlive = true;
    private bool _isFlipped;
    
    [Header ("Movement")]
    [SerializeField] private float moveSpeed = 1f;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerJump = GetComponent<PlayerJump>();
    }
    
    private void Update()
    {
        if (_isAlive == false) return;
        FlipPlayerVisual();
        Move();
        HandleMoveVisuals();
    }
    
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
    
    private void FlipPlayerVisual()
    {
        if (_moveInput.x < 0 )
        {
            //dogSprite.flipX = true;
            //var playerRotation = Quaternion.Euler(0, 180, 0);
            //gameObject.transform.rotation = playerRotation;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            _isFlipped = true;
        }
        
        else if (_moveInput.x > 0 )
        {
            //dogSprite.flipX = false;
            //var playerRotation = Quaternion.Euler(0, 0, 0);
            //gameObject.transform.rotation = playerRotation;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            _isFlipped = false;
        }
    }

    public bool GetFlip()
    {
        return _isFlipped;
    }
    
    private void Move()
    {
        var playerVelocity = new Vector2 (_moveInput.x * moveSpeed, _rb.velocity.y);
        _rb.velocity = playerVelocity;
    }

    private void HandleMoveVisuals()
    {
        var isJumping = _playerJump.GetIsJumping();
        if (_moveInput.x != 0 && !isJumping)
        {
            SetMoveAnimation(true);
        }
        
        else SetMoveAnimation(false);
    }

    private void SetMoveAnimation(bool insertBool)
    {
        animator.SetBool("isRunning", insertBool);
    }

    public void OnPlayerDeath()
    {
        _isAlive = false;
    }
}
