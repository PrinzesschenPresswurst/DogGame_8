using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float destructionTimer = 1f;
    void Start()
    {
        Invoke("DestroySelf", destructionTimer);
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
