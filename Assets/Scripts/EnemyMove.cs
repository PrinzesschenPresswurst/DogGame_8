using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private float _moveDirection = 1f;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        var enemyVelocity = new Vector2(moveSpeed * _moveDirection, _rb.velocity.y);
        _rb.velocity = enemyVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _moveDirection = -_moveDirection;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
