using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : Health
{

    public override void Update()
    {
        base.Update();
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Health: " + currHealth;
        Debug.LogError(invTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(5);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(1);
        }
    }
}
