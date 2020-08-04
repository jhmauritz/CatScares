using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperBullet : MonoBehaviour
{
    public float damageDealer;
        public float speed;
        public float offScreenTimer = 1f;
        public Rigidbody2D rb;
    
        private bool isOffScreen;
        private float isOffScreenTimer;

        public int maxHealth;
        private int currHealth;

        private bool isSpawned;
        float deathTimer = 2f;
        
    public virtual void Start()
    {
        currHealth = maxHealth;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * speed;
            isOffScreenTimer = offScreenTimer;

            isSpawned = true;
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

            if (isSpawned = true)
            {
                deathTimer -= Time.deltaTime;
                if (deathTimer <= 0)
                {
                    Die();
                }
            }
        }
    
        private void OnBecameInvisible()
        {
            isOffScreen = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<BasicBullet>())
            {
                TakeDamage(1);
            }

            if (other.gameObject.GetComponent<PlayerHealth>())
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageDealer);
            }
        }

        public void TakeDamage(int damage)
        {
            currHealth -= damage;

            if (currHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
}
