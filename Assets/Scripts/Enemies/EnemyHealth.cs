using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : Health
{

    public float damage;
    public Transform patrolPos1;
    public Transform patrolPos2;

    public override void Start()
    {
        base.Start();
        currHealth = maxHealth;
    }

    public override void Update()
    {
        base.Update();
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Health: " + currHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
