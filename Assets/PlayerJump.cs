using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] public BoxCollider2D playerCollider;
    private bool _standing;
    private bool _isJumping;
    
    private PlayerMove _playerMove;
    
    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }
    
    private void OnJump(InputValue jumpValue)
    {
        _isJumping = true;
        LayerMask mask = LayerMask.GetMask("Ground");
        _standing = playerCollider.IsTouchingLayers(mask);
        
        if (jumpValue.isPressed && _standing)
        {
            var playerVelocity = new Vector2(_playerMove._rb.velocity.x, jumpSpeed);
            _playerMove._rb.velocity = playerVelocity;
            _playerMove.animator.SetBool("isJumping", true);
        }
    }
    
    public bool GetIsJumping()
    {
        return _isJumping;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            StopJumping();
        }
    }

    public void StopJumping()
    {
        _playerMove.animator.SetBool("isJumping", false);
        _isJumping = false;
    }
}
