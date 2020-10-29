using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerStart : MonoBehaviour
{
    public bool startTutorial;

    void Start()
    {
        if(PlayerMoveMent.isFirstPlayerHubEncounter != 1)
        {
            PlayerMoveMent.isFirstPlayerHubEncounter = 1;

            startTutorial = true;
        }

        else if(PlayerMoveMent.isFirstPlayerHubEncounter == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
