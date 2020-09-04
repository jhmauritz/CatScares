using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetThingsActive : MonoBehaviour
{
    public GameObject descriptionObj;

    [HideInInspector]
    public bool onClickedActive;
    
    public void SetActive()
    {
        descriptionObj.SetActive(true);
    }

    public void SetInActive()
    {
        if (!onClickedActive)
        {
            descriptionObj.SetActive(false);
        }
    }
    
    public void SetActiveClicked()
    {
        descriptionObj.SetActive(true);
        onClickedActive = !onClickedActive;
        GetComponent<Button>().enabled = false;
        GetComponent<Button>().enabled = true;
    }
}
