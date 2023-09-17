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
    [SerializeField] private Transform bulletSpawn;
    private bool _isFlipped;
    private PlayerMove _playerMove;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    private void OnFire(InputValue jumpValue)
    {
        var bulletPosition = bulletSpawn.transform.position;
        var newBullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        newBullet.transform.SetParent(newParent);
        
        _isFlipped = _playerMove.GetFlip();
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
