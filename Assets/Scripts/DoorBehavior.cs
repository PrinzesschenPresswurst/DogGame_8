using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private ParticleSystem exitParticles;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(exitParticles, transform.position, quaternion.identity);
            _gameManager.OnExitReached();
        } 
    }
}
