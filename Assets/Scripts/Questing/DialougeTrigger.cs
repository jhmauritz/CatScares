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
    private Color visibleColor;

    private void Start()
    {
        diaPanel = GameObject.FindGameObjectWithTag("DiaPanel").GetComponent<Image>();
        diaTitle = GameObject.FindGameObjectWithTag("DiaTitle").GetComponent<TextMeshProUGUI>();
        diaDescription = GameObject.FindGameObjectWithTag("DiaDescription").GetComponent<TextMeshProUGUI>();

        diaPanel.color = invisibleColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        diaPanel.color = visibleColor;
    }
}
