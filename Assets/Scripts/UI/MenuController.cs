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
    public string savedScene;

    private SaveScene saveSceneData;

    private void Start()
    {
        saveSceneData = GetComponent<SaveScene>();
    }

    public void LoadButton()
    {
        int savedSceneJson = JsonUtility.FromJson<SaveScene.SaveData>("json").scene;
        Debug.Log(savedSceneJson);
    }

    public void LoadLastSave(string data)
    {
        
        var savedScene = JsonUtility.FromJson<SaveScene.SaveData>(data).scene;
        SceneManager.LoadScene(savedScene);
    }
}

