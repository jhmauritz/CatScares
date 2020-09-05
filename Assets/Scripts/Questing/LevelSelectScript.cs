using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectScript : MonoBehaviour
{
    public static string loadLevelName;
    
    private int levelSelectInteger;

    [Header("LevelSelectButtons")] 
    public GameObject[] levelButton;
    
    private void Start()
    {
        levelSelectInteger = PlayerMoveMent.levelsCompleted;

        for (int i = 0; i < levelSelectInteger; i++)
        {
            levelButton[i].SetActive(true);
        }

        if (!levelButton[0].activeInHierarchy)
        {
            levelButton[0].SetActive(true);
        }
    }
}
