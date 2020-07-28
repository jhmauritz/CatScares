using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SerializableVector2
{
    public float x;
    public float y;
}

[System.Serializable]
public class SaveAble
{
    public float health = 50;
    public SerializableVector2 pos;
    public int ammo;
    public int savedScene;
}
