using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMoveSpeed = 5f;
    [SerializeField] private Transform newParent;
    private SpriteRenderer _spriteRenderer;
    private bool _isFlipped;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnFire(InputValue jumpValue)
    {
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.transform.SetParent(newParent);

        if (_spriteRenderer.flipX == enabled)
        {
            _isFlipped = true;
        }
        else _isFlipped = false;
    }

    public float GetBulletMoveSpeed()
    {
        return bulletMoveSpeed;
    }

    public bool GetFaceDirection()
    {
        return _isFlipped;
    }
}
