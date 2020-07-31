using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    public float currHealth;

    public Animator anim;
    public Healthbar healthbar;

    //invulnerableTimer
    bool invulnerable;
    public float invTimer = 0.5f;

    public bool isNotInvulnerable;
    public bool isUsingHealthBar;


    public virtual void Start()
    {
        
        currHealth = maxHealth;
        if (isUsingHealthBar)
        {
            healthbar.SetMaxHealth(currHealth);
            anim = GetComponent<Animator>();
        }
        else
        {
            return;
        }
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
                healthbar.SetHealth(currHealth);
            }
        }
        else
        {
            anim.SetTrigger("isDamaged");
            currHealth -= damage;
            healthbar.SetHealth(currHealth);
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
