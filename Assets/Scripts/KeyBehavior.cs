using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyBehavior : MonoBehaviour
{

    [SerializeField] private Tilemap invisibleDoor;
    [SerializeField] private Tilemap solidDoor;
    void Start()
    {
        invisibleDoor.gameObject.SetActive(true);
        solidDoor.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            invisibleDoor.gameObject.SetActive(false);
            solidDoor.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
