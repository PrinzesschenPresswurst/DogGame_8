using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LeverBehavior : MonoBehaviour
{
    [SerializeField] private Tilemap boxesToAppear;
    
    private void Start()
    {
        boxesToAppear.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boxesToAppear.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
