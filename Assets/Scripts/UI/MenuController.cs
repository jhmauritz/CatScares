using System;
using System.Collections;
using System.Collections.Generic;
using Lowscope.Saving;
using Lowscope.Saving.Components;
using Lowscope.Saving.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject loadButton;

    private string checkforSave;

    private void Start()
    {
        checkforSave = SaveMaster.GetString("scene");
    }

    private void Update()
    {
        if (string.IsNullOrEmpty(checkforSave))
        {
            loadButton.SetActive(false);
        }
        else
        {
            loadButton.SetActive(true);
        }
    }

    public void LoadButton()
    {
        SaveMaster.SetSlot(0, false);

        string sceneName = SaveMaster.GetString("scene");
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("No level set for this game.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // Load the saved scene name
            SceneManager.LoadScene(sceneName);
        }
    }

    public void NewGameButton()
    {
        SaveMaster.DeleteSave(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

