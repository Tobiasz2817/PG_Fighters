using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CustomizeCharacterEquipmentData : MonoBehaviour, IDataInstances
{
    public static CustomizeCharacterEquipmentData Instance;
    private void CreateInstances()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this);
    }

    #region Customize Data Operations

    private readonly Dictionary<int, GameObject> customizeCharacterDict = new Dictionary<int, GameObject>();
    public void SetElementsCustomizedCharacter(int index, GameObject gameObject)
    {
        customizeCharacterDict.Add(index,gameObject);
    }
    public GameObject GetCustomizePrefab(int index)
    {
        GameObject pref;
        if (customizeCharacterDict.TryGetValue(index, out pref))
            return pref;
        
        return null;
    }

    #endregion

    #region Equipment Data Operations

    private readonly List<CustomizeEquipmentPart> currentEquipment = new List<CustomizeEquipmentPart>();
    public void SetCurrentEquipment(CustomizeEquipmentPart customizeEquipmentPart)
    {
        currentEquipment.Add(customizeEquipmentPart);
    }
    #endregion
    
    public Task IsDone()
    {
        CreateInstances();
        return Task.Delay(1);
    }
}

[Serializable]
public class CustomizeEquipmentPart
{
    public string head;
    public List<int> indexList = new List<int>();
}
