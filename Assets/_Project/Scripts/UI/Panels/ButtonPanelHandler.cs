using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPanelHandler : MonoBehaviour
{
    public Panels _panel;
    public Action<Panels> OnButtonClick;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(SelectionPanel);
    }
    private void SelectionPanel()
    {
        OnButtonClick?.Invoke(_panel);
    }
    
}