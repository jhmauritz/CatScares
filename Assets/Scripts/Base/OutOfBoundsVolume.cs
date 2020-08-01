using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            Destroy(other.gameObject);
        }
    }
}
