using System;
using TMPro;
using UnityEngine;
using Maz.String;

// TODO: Add Polling prefabs
public class CustomizePrefab : MonoBehaviour
{
    [SerializeField] private TMP_Text namePartText;
    [SerializeField] private Transform bodyContent;
    [SerializeField] private GameObject buttonHandler;
    
    private GameObject currentPrefab;
    private CustomizeSelectionEquipment _customizeSelectionEquipment;
    public string Content { private set; get; }
    public int IndexPrefab { private set; get; }

    private void Awake()
    {
        _customizeSelectionEquipment = FindObjectOfType<CustomizeSelectionEquipment>();
        if (!_customizeSelectionEquipment) throw new Exception("Customize Selection Equipment are not finded");
    }
    public void SetupPrefab(string namePart,string content)
    {
        namePartText.text = namePart;
        this.Content = content;
        IndexPrefab = 0;
    }
    public void SetupChild(CustomizeSelection customizeSelection,Sprite sprite)
    {
        var child = Instantiate(buttonHandler, bodyContent);
        var selectionHandler = child.GetComponent<CustomizeSelectionPrefab>();
        selectionHandler.Setup(customizeSelection, sprite);
        selectionHandler.OnButtonPressed += LoadNewPart;
    }
    private void LoadNewPart(CustomizeSelection customizeSelection)
    {
        var tmp = customizeSelection.customizePrefab;
        if (currentPrefab && tmp)
            if (StringOperations.CheckStrings(tmp.name,currentPrefab.name))
                tmp = null;
        
        if(currentPrefab) Destroy(currentPrefab);
        if (!tmp) return;
        
        IndexPrefab = customizeSelection.index;
        currentPrefab = Instantiate(tmp,_customizeSelectionEquipment.GetTransform(namePartText.text));
    }
}
