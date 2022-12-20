using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationLoader : MonoBehaviour
{
    public const string CUSTOMIZE_FILE = "CUSTOMIZE_FILE";
    public const string CUSTOMIZE_KEY = "CUSTOMIZE_PART_";

    public const string CUSTOMIZE_CURRENT_SELECTED = "CUSTOMIZE_CURRENT_SELECTED";
    public const string CUSTOMIZE_CURRENT_SELECTED_FILE = "CUSTOMIZE_CURRENT_SELECTED_FILE";

    public static int BasicCustomizationColor;
    
    private string lastCustomizeKey = "";
    
    private Button[] customizeButtons;

    public static event Action<List<CustomizeSelection>> OnCustomizeSelected;
    
    private void Awake() {
        customizeButtons = GetComponentsInChildren<Button>();
        
        customizeButtons[0].onClick.AddListener(() => ButtonSelected(CUSTOMIZE_KEY + 1));
        customizeButtons[1].onClick.AddListener(() => ButtonSelected(CUSTOMIZE_KEY + 2));
        customizeButtons[2].onClick.AddListener(() => ButtonSelected(CUSTOMIZE_KEY + 3));
    }

    private void OnEnable() {
        CustomizePanel.OnEnableCustomize += ButtonSelected;
    }

    private void OnDisable() {
        CustomizePanel.OnEnableCustomize -= ButtonSelected;
    }

    private void ButtonSelected(string customizeKey) {
        if (customizeKey == lastCustomizeKey) return;

        lastCustomizeKey = customizeKey;
        CustomizeCharacterEquipmentData.Instance.currentKeySelectedCustomization = customizeKey;
        SaveManager.SaveDates(CUSTOMIZE_CURRENT_SELECTED,new List<string>() { customizeKey },CUSTOMIZE_CURRENT_SELECTED_FILE,ModificationType.Replaced);
        
        var customization = SaveManager.LoadDates<CustomizeSelection>(customizeKey,CUSTOMIZE_FILE);
        OnCustomizeSelected?.Invoke(customization);
    }
}
