using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] private GameObject enemyKillParticles;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Instantiate(enemyKillParticles, transform.position, quaternion.identity);
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
