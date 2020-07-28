using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    private PlayerHealth player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    public void Save()
    {
        //Create or open file
        FileStream file = new FileStream(Application.persistentDataPath + "/player.dat", FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, player.saveable);
        file.Close();
    }

    public void Load()
    {

    }
}
