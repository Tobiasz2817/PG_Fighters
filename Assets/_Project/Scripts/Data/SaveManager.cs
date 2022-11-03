using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static string directory = "SaveData";
    public static string fileName = "MySave.data";

    public static void SaveData<T>(T saveData)
    {
        if (!DirectoryExists())
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
        
        FileStream dataStream = new FileStream(GetFullPath(), FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }

    public static T LoadData<T>()
    {
        if (SaveExsist())
        {
            try
            {
                FileStream dataStream = new FileStream(GetFullPath(), FileMode.Open);

                BinaryFormatter converter = new BinaryFormatter();
                T saveData = (T) converter.Deserialize(dataStream);

                dataStream.Close();
                return saveData;
            }
            catch (SerializationException exc)
            {
                Debug.Log("Failed to load file");
            }
        }

        return default;
    }

    public static bool SaveExsist()
    {
        return File.Exists(GetFullPath());
    }

    public static bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }

    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + directory + "/" + fileName;
    }
}

