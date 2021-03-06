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

    public bool isEnemy;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(isEnemy)
        {
            EnemyCollision(collision);
        }
        else if(!isEnemy)
        {
            RegularCollision(collision);
        }
    }

    void EnemyCollision(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>())
                {
                    return;
                }
        else if (collision.gameObject.GetComponent<PlayerHealth>())
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageDealer);
                Destroy(gameObject);
            }

    }

    void RegularCollision(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealth>() || collision.CompareTag("CheckPoint"))
        {
            return;
        }
        else if (collision.gameObject.GetComponent<EnemyHealth>())
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageDealer);
                Destroy(gameObject);
            }
        else if(!collision.gameObject.GetComponent<PlayerHealth>() || collision.CompareTag("CheckPoint"))
        {
            Destroy(gameObject);
        }
    }
}

