using System;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class CustomizeSelectionEquipment : MonoBehaviour
{
    private Dictionary<string, Transform> contents = new Dictionary<string, Transform>();
    
    private CustomizeData _customizeData;
    private void Awake()
    {
        _customizeData = FindObjectOfType<CustomizeData>();
        if (!_customizeData) throw new Exception("Customize Data not finded");
        FindContents(transform, ref contents);
    }
    private void FindContents(Transform reserachPrefab, ref Dictionary<string, Transform> contents_)   
    {
        if (!reserachPrefab) throw new Exception("Customize Prefab are null");
        
        var compo = reserachPrefab.transform.GetComponentsInChildren<Transform>();
        
        foreach (var child in compo)
            foreach (var contentKey in _customizeData.GetCustomizeList())
                if (child.name == contentKey.nameMainPart)
                    foreach (var secoundPart in contentKey.secoundPartList)
                        contents_.Add(secoundPart.nameFirstPart,child);
    }

    public Transform GetTransform(string content)
    {
        return contents[content];
    }
}
