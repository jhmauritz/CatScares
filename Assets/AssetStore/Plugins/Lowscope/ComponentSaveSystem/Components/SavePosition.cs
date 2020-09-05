using System;
using Lowscope.Saving;
using UnityEngine;

namespace Lowscope.Saving.Components
{
    /// <summary>
    /// Example class of how to store a position.
    /// Also very useful for people looking for a simple way to store a position.
    /// </summary>

    [AddComponentMenu("Saving/Components/Save Position"), DisallowMultipleComponent]
    public class SavePosition : MonoBehaviour, ISaveable
    {
        Vector3 lastPosition;
        private int completedLevels;

        [Serializable]
        public struct SaveData
        {
            public Vector3 position;
            public int levels;
        }

        private void Start()
        {
            string checkForSave = SaveMaster.GetString("scene");
            
            
            if (string.IsNullOrEmpty(checkForSave))
            {
                return;
            }
            else
            {
                SaveMaster.SyncLoad();
            }
        }

        public void OnLoad(string data)
        {
            var pos = JsonUtility.FromJson<SaveData>(data).position;
            var level = JsonUtility.FromJson<SaveData>(data).levels;
            transform.position = pos;
            lastPosition = pos;
            PlayerMoveMent.levelsCompleted = level;
            completedLevels = level;
        }

        public string OnSave()
        {
            lastPosition = transform.position;
            completedLevels = PlayerMoveMent.levelsCompleted;
            return JsonUtility.ToJson(new SaveData { position = lastPosition, levels = completedLevels});
        }

        public bool OnSaveCondition()
        {
            return lastPosition != transform.position || completedLevels != PlayerMoveMent.levelsCompleted;
        }
    }
}
