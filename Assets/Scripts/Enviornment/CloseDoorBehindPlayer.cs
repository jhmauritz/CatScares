using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorBehindPlayer : MonoBehaviour
{
    GameObject doorTrap;

    public List<GameObject> targets;

    void Start()
    {
        doorTrap = GameObject.FindGameObjectWithTag("DoorTrap");
        doorTrap.SetActive(false);
    }

    void Update()
    {
        if(targets.Count == 0)
        {
            doorTrap.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            doorTrap.SetActive(true);
        }
    }
}
