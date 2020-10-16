using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    void Start()
    {
        EndLevelTeleporter.questItems.Add(this);
    }

    void OnDestroy()
    {
        if(EndLevelTeleporter.questItems.Contains(this))
        {
            EndLevelTeleporter.questItems.Remove(this);
        }
    }
}
