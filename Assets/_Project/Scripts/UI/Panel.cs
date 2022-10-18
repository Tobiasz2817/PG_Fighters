using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Services.Core;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Action OnPanelSelection;
    public Action OnPanelDeselection;
    public Panels myType;
    
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        DeselectionPanel();
    }

    public void OnEnable()
    {
        OnPanelSelection += SelectionPanel;
        OnPanelDeselection += DeselectionPanel;
    }

    public void OnDisable()
    {
        OnPanelSelection -= SelectionPanel;
        OnPanelDeselection -= DeselectionPanel;
    }

    protected virtual void SelectionPanel()
    {
        SmoothPanelSelection();
    }
    protected virtual void DeselectionPanel()
    {
        SmoothPanelDeselection();
    }

    private void SmoothPanelSelection()
    {
        _canvasGroup.DOFade(1, 0.05f);
    }
    private void SmoothPanelDeselection()
    {
        _canvasGroup.DOFade(0, 0.05f);
    }
}
