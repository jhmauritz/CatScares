using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeTrigger : MonoBehaviour
{
    private Image diaPanel;
    private TextMeshProUGUI diaTitle;
    private TextMeshProUGUI diaDescription;
    
    [SerializeField] private string dialougeTitle;
    [SerializeField] private string dialougeDescription;
    [SerializeField] private Color invisibleColor;
    private Color visibleColorPanel;
    private Color visibleColorTitle;
    private Color visibleColorDescription;

    private void Awake()
    {
        diaPanel = GameObject.FindGameObjectWithTag("DiaPanel").GetComponent<Image>();
        diaTitle = GameObject.FindGameObjectWithTag("DiaTitle").GetComponent<TextMeshProUGUI>();
        diaDescription = GameObject.FindGameObjectWithTag("DiaDescription").GetComponent<TextMeshProUGUI>();
        
        visibleColorPanel = diaPanel.color;
        visibleColorTitle = diaTitle.color;
        visibleColorDescription = diaDescription.color;
    }

    private void Start()
    {
        InvisibleBox();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerInputs>())
        {
            VisibleBox();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerInputs>())
        {
            InvisibleBox();
        }
    }

    private void VisibleBox()
    {
        diaPanel.color = visibleColorPanel;
        diaTitle.color = visibleColorTitle;
        diaDescription.color = visibleColorDescription;

        diaTitle.text = dialougeTitle;
        diaDescription.text = dialougeDescription;
    }

    private void InvisibleBox()
    {
        diaPanel.color = invisibleColor;
        diaTitle.color = invisibleColor;
        diaDescription.color = invisibleColor;
    }
}
