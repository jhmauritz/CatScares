using Lowscope.Saving;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SaveMaster.WriteActiveSaveToDisk();
        }
    }
}
