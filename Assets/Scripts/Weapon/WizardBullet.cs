using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBullet : BulletBase
{
    private Transform player;
    
    public override void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        if (player != null)
        {
            Vector3 dist = (player.position - transform.position).normalized;


            rb.velocity = dist * speed;
        }
    }
}
