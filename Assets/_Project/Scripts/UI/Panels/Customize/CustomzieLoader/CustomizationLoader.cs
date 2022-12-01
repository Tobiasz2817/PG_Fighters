using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationLoader : MonoBehaviour
{
    private readonly List<List<CustomizeSelection>> equipments = new List<List<CustomizeSelection>>();

    public const string CUSTOMIZE_FILE = "CUSTOMIZE_FILE";
    

    [SerializeField] private List<Button> customizeButtons;
    
    private void Awake()
    {
        for (int i = 1; i <= customizeButtons.Count; i++)
        {
            customizeButtons[i].onClick.AddListener(() => { ButtonSelected("CUSTOMIZE_PART_" + i); });
        }
        
        customizeButtons[0].onClick.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ButtonSelected(string customizeName)
    {
        CustomizeCharacterEquipmentData.Instance.currentKeySelectedCustomization = customizeName;
    }
    private void SelectCurrentEquipiment()
    {
        
    }
}
