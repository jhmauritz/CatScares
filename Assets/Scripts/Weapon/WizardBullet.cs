using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBullet : BulletBase
{
    private Transform player;
    
    public override void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        

        rb.velocity = player.forward * speed * Time.deltaTime;
    }
}
