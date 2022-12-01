using System.Collections.Generic;
using UnityEngine;


public enum Panels
{
    NonePanel,
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
        _panels = GetComponentsInChildren<Panel>();
    }

    private void OnEnable()
    {
        ButtonPanelHandler.OnButtonClick += ButtonHandler;
    }
    private void OnDisable()
    {
        ButtonPanelHandler.OnButtonClick -= ButtonHandler;
    }
    private void ButtonHandler(Panels typePanel)
    {
        var (currentPanel, otherPanels) = FindPanels(typePanel);
        if (!currentPanel || otherPanels.Count == 0) return;
        if (currentSelectedPanel == currentPanel) return;
        
        Debug.Log("Invoke Button handler");
        
        otherPanels.ForEach(panel => { panel.OnPanelDeselection?.Invoke();});
        currentPanel.OnPanelSelection?.Invoke();
        
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
