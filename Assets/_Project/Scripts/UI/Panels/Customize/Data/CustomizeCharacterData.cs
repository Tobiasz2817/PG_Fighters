using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CustomizeCharacterData : MonoBehaviour, IDataInstances
{
    public static CustomizeCharacterData Instance;
    
    
    private void Awake()
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

    private readonly Dictionary<string,List<int>> currentEquipment = new Dictionary<string,List<int>>();
    public void SetCurrentEquipment(string nameContent, int listIndex)
    {
        if(currentEquipment.ContainsKey(nameContent))
            currentEquipment[nameContent].Add(listIndex);
        else
            currentEquipment.Add(nameContent,new List<int>(){ listIndex });
    }
    #endregion
    
    public Task IsDone()
    {
        return Task.Run(Awake);
    }
}
