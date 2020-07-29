using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lowscope.Saving;
using System;
using UnityEngine.SceneManagement;

namespace Lowscope.Saving.Components
{
    public class SaveScene : MonoBehaviour, ISaveable
    {
        int savedScene;

        [Serializable]
        public struct SaveData
        {
            public int scene;
        }
        

        public void OnLoad(string data)
        {
            //int SavedScene = SceneManager.GetActiveScene().buildIndex;
            int SavedScene = JsonUtility.FromJson<SaveData>(data).scene;
            savedScene = SavedScene;
        }

        public string OnSave()
        {
            savedScene = SceneManager.GetActiveScene().buildIndex;
            return JsonUtility.ToJson(new SaveData { scene = savedScene });
        }

        public bool OnSaveCondition()
        {
            return savedScene != SceneManager.GetActiveScene().buildIndex;
        }
    }
}
