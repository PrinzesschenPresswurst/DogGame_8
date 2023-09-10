using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    private PlayerMove _playerMove;
    private PlayerJump _playerJump;
    private GameManager _gameManager;
    private Collider2D[] _colliders;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerJump = GetComponent<PlayerJump>();
        _gameManager = FindObjectOfType<GameManager>();
        _colliders = GetComponentsInChildren<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Fire":
                Debug.Log("died in fire");
                PlayerDeath();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("collided with enemy");
                PlayerDeath();
                break;
        }
    }

    private void PlayerDeath()
    {
        _playerMove.OnPlayerDeath();
        _playerJump.OnPlayerDeath();
        StartCoroutine(DeathFeedback());
    }

    IEnumerator DeathFeedback()
    {
        _playerMove.animator.SetTrigger("OnDeath");
        deathParticles.Play();
        
        float deathJump = 3f;
        var playerVelocity = new Vector2(_playerMove._rb.velocity.x, deathJump);
        _playerMove._rb.velocity = playerVelocity;
        
        foreach (var playerCollider in _colliders)
        {
            playerCollider.gameObject.SetActive(false);
        }
        
        yield return new WaitForSeconds(0.2f);
        mainCamera.backgroundColor = Color.red;
        
        yield return new WaitForSeconds(1f);
        _gameManager.Death();
    }
}
