using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundPicker : MonoBehaviour
{
    [SerializeField] public Sprite nightMareBG;
    [SerializeField] public Sprite regBG;
    private SpriteRenderer bg;

    void Start() 
    {
        bg = GetComponent<SpriteRenderer>();

        BGPicker();
        ResizeSpriteToScreen();
    }

    private void ResizeSpriteToScreen()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(1, 1, 1);

        float width = spriteRenderer.bounds.size.x;
        float height = spriteRenderer.bounds.size.y;

        Debug.Log("width" + width);
        Debug.Log("height" + height);

        float worldScreenHeight = (float)(Camera.main.orthographicSize * 2f);
        float worldScreenWidth = (float)(worldScreenHeight / Screen.height * Screen.width);

        transform.localScale = new Vector2(worldScreenWidth/width, worldScreenHeight/height);
    }

    private void BGPicker()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        if(sceneName.Contains("Fear"))
        {
            bg.sprite = nightMareBG;
        }
        else
        {
            bg.sprite = regBG;
        }
    }
}
