﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : Health
{

    public float damage;

    public override void Update()
    {
        base.Update();
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Health: " + currHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}