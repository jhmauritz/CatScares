using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionRef : MonoBehaviour
{
    public string fearName;

    public void SelecetFearButton()
    {
        LevelSelectScript.loadLevelName = fearName;
    }
}
