using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    public float currHealth;

    Animator anim;

    //invulnerableTimer
    bool invulnerable;
    public float invTimer = 0.5f;

    public bool isNotInvulnerable;


    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        currHealth = maxHealth;
    }

    public virtual void Update()
    {
        if(invulnerable)
        {
            invTimer -= Time.deltaTime;
            if(invTimer <= 0)
            {
                invTimer = 0.5f;
                invulnerable = false;
            }
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if (!isNotInvulnerable)
        {
            if (!invulnerable)
            {
                invulnerable = true;
                anim.SetTrigger("isDamaged");
                currHealth -= damage;
            }
        }
        else
        {
            anim.SetTrigger("isDamaged");
            currHealth -= damage;
        }

        if(currHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
