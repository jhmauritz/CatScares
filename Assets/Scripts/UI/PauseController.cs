using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject[] uiArrayNonStatic;

    public GameObject levelSelectMenu;
    public GameObject pauseMenu;

    private static bool isForMenu;
    
    private void Update()
    {
        ActivateLevelSelect();

        Pausing();
    }

    //pause the same way the level select works instead of how it is now
    public void Pausing()
    {
        if (PlayerInputs.isPaused && !levelSelectMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            levelSelectMenu.SetActive(false);
            
            isForMenu = true;
            Freeze();
        }
        else if (!PlayerInputs.isPaused && !PlayerInputs.worldUIButtonPressed)
        {
            UnFreeze();
            isForMenu = false;
            
            foreach (GameObject item in uiArrayNonStatic)
            {
                item.SetActive(false);
            }
        }
    }


    public void ActivateLevelSelect()
    {
        if (PlayerInputs.worldUIButtonPressed && !pauseMenu.activeInHierarchy)
        {
            levelSelectMenu.SetActive(true);
                
            isForMenu = true;
            Freeze();
        }
        else if (!PlayerInputs.worldUIButtonPressed)
        {
            UnFreeze();
            isForMenu = false;
                
            levelSelectMenu.SetActive(false);
        }
    }

    public static void Freeze()
    {
        Time.timeScale = 0f;

        if (isForMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public static void UnFreeze()
    {
        Time.timeScale = 1f;
        
        if (isForMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
