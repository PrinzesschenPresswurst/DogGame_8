using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header ("Shared")]
    [SerializeField] public BoxCollider2D playerCollider;
    [SerializeField] public Animator animator;
    public Vector2 _moveInput;
    public Rigidbody2D _rb;
    private PlayerJump _playerJump;
    
    [Header ("Movement")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private SpriteRenderer dogSprite;
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerJump = GetComponent<PlayerJump>();
    }
    
    private void Update()
    {
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
            dogSprite.flipX = true;
        }
        
        else if (_moveInput.x > 0 )
        {
            dogSprite.flipX = false;
        }
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
}
