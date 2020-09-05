using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLevelText : MonoBehaviour
{
    private TextMeshProUGUI levelText;
    
    private void Start()
    {
        levelText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        levelText.text = LevelSelectScript.loadLevelName;
    }
}
