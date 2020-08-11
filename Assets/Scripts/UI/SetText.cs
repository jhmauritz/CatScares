using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    public string interactText;

    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();

        tmp.text = "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            tmp.text = interactText;
            PlayerInputs.isPlayerHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            tmp.text = "";
            PlayerInputs.isPlayerHere = false;
            PlayerInputs.worldUIButtonPressed = false;
        }
    }
}
