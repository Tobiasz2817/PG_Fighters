using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;


public class SaveManager
{
    [Serializable]
    private class Wrapper<T>
    {
        public List<T> Items;
    }
    
    private static string directory = "SaveData";
    private static string typeFile = ".save";

    public static void SaveDates<T>(T[] saveData,string fileName)
    {
        if (!DirectoryExists())
            Directory.CreateDirectory(directory);

        // Load and append
        Wrapper<T> wrapper = new Wrapper<T>();
        if (SaveExsist(fileName))
            wrapper.Items = LoadAndAppend(saveData, fileName);
        else
            wrapper.Items = saveData.ToList();
        
        // Open stream and write to file
        FileStream dataStream = new FileStream(GetFullPath(fileName), FileMode.Create);
        using BinaryWriter writer = new BinaryWriter(dataStream);

        var jsonString = JsonUtility.ToJson(wrapper, true);
        writer.Write(jsonString);
        
        dataStream.Close();
    }

    private static List<T> LoadAndAppend<T>(T[] newData,string fileName)
    {
        var loadedDates = LoadDates<T>(fileName);
        foreach (var tmp in newData)
            if(!loadedDates.Contains(tmp)) loadedDates.Add(tmp);

        return loadedDates;
    }
    public static List<T> LoadDates<T>(string fileName)
    {
        if (SaveExsist(fileName))
        {   
            try
            {
                FileStream dataStream = new FileStream(GetFullPath(fileName), FileMode.Open);

                using BinaryReader reader = new BinaryReader(dataStream);
                var jsonString = reader.ReadString();
                Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonString);

                dataStream.Close();
            
                return wrapper.Items;
            }
            catch (SerializationException exc)
            {
                Debug.Log("Failed to load file");
            }
        }
        
        
        return new List<T>(){};
    }

    private static bool SaveExsist(string fileName)
    {
        return File.Exists(GetFullPath(fileName));
    }

    private static bool DirectoryExists()
    {
        return Directory.Exists(directory);
    }

    private static string GetFullPath(string fileName) 
    {
        return directory + "/" + fileName + typeFile;
    }
}

