﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float damageDealer;
    public float speed;
    public float offScreenTimer = 1f;
    public Rigidbody2D rb;

    private bool isOffScreen;
    private float isOffScreenTimer;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        isOffScreenTimer = offScreenTimer;
    }

    private void Update()
    {
        if (isOffScreen)
        {
            isOffScreenTimer -= Time.deltaTime;
            if (isOffScreenTimer <= 0)
            {
                Destroy(gameObject);
                isOffScreen = false;
                isOffScreenTimer = offScreenTimer;
            }
        }
    }

    private void OnBecameInvisible()
    {
        isOffScreen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageDealer);
            Destroy(gameObject);
        }
    }
}
