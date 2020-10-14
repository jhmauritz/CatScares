using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lowscope.Saving;

public class CheckPoint : MonoBehaviour
{
    public int checkpointNumber;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerHealth>())
        {

            PlayerMoveMent.checkpointIndexCompleted = checkpointNumber;

            SaveCurrentData();
        }
    }

    private void SaveCurrentData()
    {
        SaveMaster.SetSlot(0, false);
            SaveMaster.SetString("scene", gameObject.scene.name);
            SaveMaster.WriteActiveSaveToDisk();
            Debug.Log("Saved");
    }
}
