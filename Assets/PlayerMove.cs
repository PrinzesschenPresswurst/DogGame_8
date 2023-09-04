using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header ("Movement")]
    private Vector2 _moveInput;
    [SerializeField] private float moveSpeed = 1f;
    private Rigidbody2D _rb;
    
    [Header ("Visuals")]
    [SerializeField] private SpriteRenderer dogSprite;
    [SerializeField] private Animator animator;
    
    [Header ("Jumps")]
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private BoxCollider2D playerCollider;
    private bool _standing;
    private bool _isJumping;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        HandleFlips();
        Move();
        HandleMoveVisuals();
    }
    
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
    
    private void HandleFlips()
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
        if (_moveInput.x != 0 && !_isJumping)
        {
            SetMoveAnimation(true);
        }
        
        else SetMoveAnimation(false);
    }

    private void SetMoveAnimation(bool insertBool)
    {
        animator.SetBool("isRunning", insertBool);
    }
    
    private void OnJump(InputValue jumpValue)
    {
        _isJumping = true;
        LayerMask mask = LayerMask.GetMask("Ground");
        _standing = playerCollider.IsTouchingLayers(mask);
        
        if (jumpValue.isPressed && _standing)
        {
            var jumpVelocity = new Vector2(_rb.velocity.x, jumpSpeed);
            _rb.velocity = jumpVelocity;
            animator.SetBool("isJumping", true);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            _isJumping = false;
        }
    }
}
