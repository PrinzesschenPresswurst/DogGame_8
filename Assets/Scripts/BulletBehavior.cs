using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletBehavior : MonoBehaviour
{
    private PlayerShoot _playerShoot;
    private float _bulletMoveSpeed;
    private bool _flipped;
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _playerShoot = FindObjectOfType<PlayerShoot>();
        _bulletMoveSpeed = _playerShoot.GetBulletMoveSpeed();
        _flipped = _playerShoot.GetFaceDirection();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        if (_flipped)
        {
            BulletFly(-1);
        }

        else if (!_flipped)
        {
            BulletFly(1);
        }
    }

    private void BulletFly(float direction)
    {
        var bulletVelocity = new Vector2 (direction * _bulletMoveSpeed, _rb.velocity.y);
        _rb.velocity = bulletVelocity;
    }
}
