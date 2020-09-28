using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundPicker : MonoBehaviour
{
    [SerializeField] public Sprite nightMareBG;
    [SerializeField] public Sprite regBG;
    private Image bg;

    void Start() 
    {
        bg = GetComponent<Image>();

        BGPicker();
    }

    private void BGPicker()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        if(sceneName.Contains("Tut"))
        {
            bg.sprite = nightMareBG;
        }
        else
        {
            bg.sprite = regBG;
        }
    }
}
