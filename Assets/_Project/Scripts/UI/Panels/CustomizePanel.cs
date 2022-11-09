using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizePanel : Panel
{
    [SerializeField] private GameObject customizePrefab;
    protected override void Start()
    {    
        base.Start();
    }
    protected override void OnSelectionPanel()
    {
        base.OnSelectionPanel();
        SetActiveCustomizeCharacter(true);
    }
    protected override void OnDeselectionPanel()
    {
        base.OnDeselectionPanel();
        SetActiveCustomizeCharacter(false);
    }

    private void SetActiveCustomizeCharacter(bool isActive)
    {
        customizePrefab.SetActive(isActive);
    }
    
}
