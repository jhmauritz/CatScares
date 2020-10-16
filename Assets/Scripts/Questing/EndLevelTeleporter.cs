using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTeleporter : MonoBehaviour
{
    public static List<QuestItem> questItems;

    // Start is called before the first frame update
    void Awake()
    {
        questItems = new List<QuestItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(questItems.Count <= 0)
        {
            SceneManager.LoadScene("PlayerStart");
        }
    }
}
