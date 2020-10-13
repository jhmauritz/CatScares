using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsRemove : MonoBehaviour
{
    CloseDoorBehindPlayer closeDoorBehindPlayer;

    void Start()
    {
        closeDoorBehindPlayer = FindObjectOfType<CloseDoorBehindPlayer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<BasicBullet>())
        {
            closeDoorBehindPlayer.targets.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
}
