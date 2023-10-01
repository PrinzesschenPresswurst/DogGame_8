using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private float _moveDirection = 1f;
    private Rigidbody2D _rb;
    [SerializeField] private Collider2D feetCollider;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
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
        gameObject.transform.localScale = new Vector3(_moveDirection, 1, 1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("trigger exit" + other.gameObject.name);
        _moveDirection = -_moveDirection;
        gameObject.transform.localScale = new Vector3(_moveDirection, 1, 1);
    }
}
