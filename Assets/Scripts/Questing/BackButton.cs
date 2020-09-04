using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void BackButtonFunction()
    {
        SetThingsActive[] clickedArray = FindObjectsOfType<SetThingsActive>();

        DescriptionRef[] descArray = FindObjectsOfType<DescriptionRef>();

        foreach (var item in clickedArray)
        {
            item.onClickedActive = false;
            foreach (var items in descArray)
            {
                items.gameObject.SetActive(false);
            }
        }
    }
}
