using System;
using UnityEngine;
using UnityEngine.UI;

public struct CustomizeSelection
{
    public GameObject customizePrefab;
    public int index;
}
public class CustomizeSelectionHandler : MonoBehaviour
{
    private CustomizeSelection customizeSelection;
    public Action<CustomizeSelection> OnButtonPressed;

    private void Setup() => AddChildrenListner();
    public void Setup(CustomizeSelection customizeSelection_,Sprite sprite)
    {
        Setup();
        SetImageSprite(sprite);
        SetCustomizeSelection(customizeSelection_);
    }
    private void AddChildrenListner()
    {
        foreach (var button in GetComponentsInChildren<Button>())
        {
            if (!button) Destroy(this);
            button.onClick.AddListener(ButtonPressed);
        }
    }
    private void SetCustomizeSelection(CustomizeSelection customizeSelection_) => this.customizeSelection = customizeSelection_;
    private void SetImageSprite(Sprite spirte) => GetComponent<Image>().sprite = spirte;
    private void ButtonPressed() => OnButtonPressed?.Invoke(customizeSelection);
}
