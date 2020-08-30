using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject[] uiArrayNonStatic;

    public GameObject levelSelectMenu;
    
    private void Update()
    {
        ActivateLevelSelect();

        if (PlayerInputs.isExitPause)
        {
            ExitPausing();
        }
    }

    //pause the same way the level select works instead of how it is now
    public void ExitPausing()
    {
        PlayerInputs.isExitPause = false;
        PlayerInputs.worldUIButtonPressed = false;
        foreach (GameObject item in uiArrayNonStatic)
        {
            item.SetActive(false);
        }
    }

    public void ActivateLevelSelect()
    {
        if (PlayerInputs.worldUIButtonPressed && PlayerInputs.isPlayerHere)
        {
            if (levelSelectMenu != null)
            {
                levelSelectMenu.SetActive(true);
            }
        }
        else if (!PlayerInputs.worldUIButtonPressed)
        {
            if (levelSelectMenu != null)
            {
                levelSelectMenu.SetActive(false);
            }
        }
    }

}
