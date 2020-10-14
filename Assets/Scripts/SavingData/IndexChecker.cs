using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexChecker : MonoBehaviour
{

    bool start;
    float timer = 0.5f;
    public int objectIndexAt;

    void Start()
    {
        start = true;
    }
    void OnEnable()
    {
        if(PlayerMoveMent.checkpointIndexCompleted > objectIndexAt)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(start)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                start = false;
                if(PlayerMoveMent.checkpointIndexCompleted > objectIndexAt)
                {
                    gameObject.SetActive(false);
                }

            }
        }
    }
}
