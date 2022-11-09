using System;
using UnityEngine;
using UnityEngine.UI;

public struct CustomizeSelection
{
    public GameObject customizePrefab;
    public int index;
}
public class CustomizeSelectionPrefab : MonoBehaviour
{
    private CustomizeSelection customizeSelection;
    public Action<CustomizeSelection> OnButtonPressed;

    [SerializeField] private Button buttonHandler;
    [SerializeField] private Image partImage;
    
    public void Setup(CustomizeSelection customizeSelection,Sprite sprite)
    {
        AddButtonListner();
        SetImageSprite(sprite);
        SetCustomizeSelection(customizeSelection);
    }
    private void AddButtonListner() => buttonHandler.onClick.AddListener(ButtonPressed);
    private void SetCustomizeSelection(CustomizeSelection customizeSelection) => this.customizeSelection = customizeSelection;
    private void SetImageSprite(Sprite spirte) => partImage.sprite = spirte;
    private void ButtonPressed() => OnButtonPressed?.Invoke(customizeSelection);
}
