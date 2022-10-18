using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Panels
{
    CreatePanel,
    LobbiesPanel,
    WaitingPanel,
    CustomizePanel,
    OptionsPanel,
}
public class PanelActivity : MonoBehaviour
{
    private Panel[] _panels;
    private Panel currentSelectedPanel;
    private ButtonPanelHandler[] _buttonsHandler;
    
    private void Awake()
    {
        _buttonsHandler = GetComponentsInChildren<ButtonPanelHandler>();
        _panels = GetComponentsInChildren<Panel>();
    }

    private void OnEnable()
    {
        foreach (var buttonHandler in _buttonsHandler)
        {
            buttonHandler.OnButtonClick += ButtonHandler;
        }
    }
    private void OnDisable()
    {
        foreach (var buttonHandler in _buttonsHandler)
        {
            buttonHandler.OnButtonClick -= ButtonHandler;
        }
    }
    private void ButtonHandler(Panels typePanel)
    {
        var (currentPanel, otherPanels) = FindPanels(typePanel);
        if (!currentPanel || otherPanels.Count == 0) return;
        if (currentSelectedPanel == currentPanel) return;
        
        Debug.Log("Invoke Button handler");
        
        currentPanel.OnPanelSelection?.Invoke();
        otherPanels.ForEach(panel => { panel.OnPanelDeselection?.Invoke();});

        currentSelectedPanel = currentPanel;
    }

    (Panel,List<Panel>) FindPanels(Panels typePanel)
    {
        Panel currentPanel = null;
        List<Panel> othersPanel = new List<Panel>();
        foreach (Panel panel in _panels)
        {
            if (panel.myType == typePanel)
                currentPanel = panel;
            else
                othersPanel.Add(panel);
        }
        
        return (currentPanel,othersPanel);
    }
}