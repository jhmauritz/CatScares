using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstHubEncounter : MonoBehaviour
{
    void Update()
    {
        if(PlayerMoveMent.isFirstPlayerHubEncounter == 1)
        {
            StartTutorialForHub();
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }

    void StartTutorialForHub()
    {
        
    }
}
