using System;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Action OnPanelSelection;
    public Action OnPanelDeselection;
    public Panels myType;
    
    private CanvasGroup _canvasGroup;

    [Header("Canvas Group Settings")] 
    [SerializeField]
    protected float alphaDuration = 0.8f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    protected virtual void Start()
    {
        OnDeselectionPanel();
    }

    public void OnEnable()
    {
        OnPanelSelection += OnSelectionPanel;
        OnPanelDeselection += OnDeselectionPanel;
    }

    public void OnDisable()
    {
        OnPanelSelection -= OnSelectionPanel;
        OnPanelDeselection -= OnDeselectionPanel;
    }

    protected virtual void OnSelectionPanel()
    {
        SetInteractable(true);
        SetBlockRaycasts(true);
        SmoothSelectionPanel();
    }
    protected virtual void OnDeselectionPanel()
    {
        SetInteractable(false);
        SetBlockRaycasts(false);
        SmoothDeselectionPanel();
    }
    private void SmoothSelectionPanel()
    {
        _canvasGroup.DOFade(1, alphaDuration);
    }
    private void SmoothDeselectionPanel()
    {
        _canvasGroup.DOFade(0, alphaDuration / 2);
    }
    private void SetBlockRaycasts(bool isRaycasts)
    {
        _canvasGroup.blocksRaycasts = isRaycasts;
    }
    private void SetInteractable(bool isInteractable)
    {
        _canvasGroup.interactable = isInteractable;
    }
}
