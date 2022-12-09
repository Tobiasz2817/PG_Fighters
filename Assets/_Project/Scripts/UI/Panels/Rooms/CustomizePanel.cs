using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomizePanel : Panel
{
    [SerializeField] private GameObject customizePrefab;
    [SerializeField] private Button button;

    public static event Action OnSaveChanges;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {    
        base.Start();
        button.onClick.AddListener(SaveChanges);
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
    public void SaveChanges()
    {
        OnSaveChanges?.Invoke();
    }
}
