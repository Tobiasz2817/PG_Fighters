using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CustomizeCharacterEquipment : MonoBehaviour
{
    private readonly List<CustomizeSelectionTmp> currentEquipment = new List<CustomizeSelectionTmp>();
    private readonly Dictionary<string,Transform> contents = new Dictionary<string, Transform>();

    [SerializeField] 
    private CustomizeData _customizeData;

    private void OnEnable()
    {
        CustomizeSelectionPrefab.OnCustomizeSelectionPart += EquipPart;
        CustomizePanel.OnSaveChanges += SaveChanges;
    }

    private void OnDisable()
    {
        CustomizeSelectionPrefab.OnCustomizeSelectionPart -= EquipPart;
        CustomizePanel.OnSaveChanges -= SaveChanges;
    }

    private void Start()
    {
        FindContents(transform);
    }
    
    private void FindContents(Transform reserachPrefab)   
    {
        if (!reserachPrefab) throw new Exception("Customize Prefab are null");
        
        var compo = reserachPrefab.transform.GetComponentsInChildren<Transform>();

        foreach (var child in compo)
            foreach (var contentKey in _customizeData.GetCustomizeList())
                if (child.name == contentKey.nameMainPart)
                {
                    contents.Add(contentKey.nameMainPart,child);
                    foreach (var secoundPart in contentKey.secoundPartList)
                        currentEquipment.Add(new CustomizeSelectionTmp(new CustomizeSelection(contentKey.nameMainPart,secoundPart.nameFirstPart,-1),null));
                    
                }
    }

    private void EquipPart(CustomizeSelection customizeSelection, GameObject prefab)
    {
        Debug.Log("TAK");
        for (int i = 0; i < currentEquipment.Count; i++)
        {
            Debug.Log("TAK");
            if (currentEquipment[i].customizeSelection.secoundPart == customizeSelection.secoundPart)
            {
                if (currentEquipment[i].prefab != null)
                    Destroy(currentEquipment[i].prefab);

                GameObject newObject = Instantiate(prefab,contents[currentEquipment[i].customizeSelection.contentName]);
                currentEquipment[i] = new CustomizeSelectionTmp(customizeSelection,newObject);
            }
        }
    }
    private void SaveChanges()
    {
        List<CustomizeSelection> customizeSelections = new List<CustomizeSelection>();
        foreach (var current in currentEquipment)
        {
            customizeSelections.Add(current.customizeSelection);
        }

        SaveManager.SaveDates("TEST",customizeSelections,CustomizationLoader.CUSTOMIZE_FILE);
    }

    public void ClearSaves()
    {
        foreach (var equipment in currentEquipment)
        { 
            Destroy(equipment.prefab);
        }
        currentEquipment.Clear();
    }
    public void EquipLoadParts(List<CustomizeSelection> customizationEquipmetns)
    {
        ClearSaves();

        foreach (var current in customizationEquipmetns)
        {
            var newObject =
                Instantiate(
                    CustomizeCharacterEquipmentData.Instance.GetCustomizePrefab(current.index),
                    contents[current.contentName]);
                
            currentEquipment.Add(new CustomizeSelectionTmp(current,newObject));
        }
    }
}

public class CustomizeSelectionTmp
{
    public CustomizeSelection customizeSelection;
    public GameObject prefab;

    public CustomizeSelectionTmp(CustomizeSelection customizeSelection, GameObject prefab)
    {
        this.customizeSelection = customizeSelection;
        this.prefab = prefab;
    }
}