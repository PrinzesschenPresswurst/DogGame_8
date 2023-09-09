using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private float climbSpeed = 5f;
    private bool _isAtLadder;
    private float _rbDefaultGravityScale;
    
    private PlayerMove _playerMove;
    private PlayerJump _playerJump;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerJump = GetComponent<PlayerJump>();
        _rbDefaultGravityScale = _playerMove._rb.gravityScale;
    }

    private void Update()
    {
        Climb();
    }

    private void Climb()
    {
        LayerMask mask = LayerMask.GetMask("Ladder");
        _isAtLadder = _playerJump.playerCollider.IsTouchingLayers(mask);
        
        if (_isAtLadder)
        {
            _playerJump.StopJumping();
            _playerMove._rb.gravityScale = 0;
            
            var playerVelocity = new Vector2 (_playerMove._rb.velocity.x, _playerMove._moveInput.y * climbSpeed);
            _playerMove._rb.velocity = playerVelocity;

            if (_playerMove._moveInput.y != 0)
            {
                _playerMove.animator.SetBool("isClimbing", true);
            }
            
            else if (_playerMove._moveInput.y == 0)
            {
                _playerMove.animator.SetBool("isClimbing", false);
            }
        }

        else
        {
            _playerMove._rb.gravityScale = _rbDefaultGravityScale;
            _playerMove.animator.SetBool("isClimbing", false);
        }
        
    }
}
