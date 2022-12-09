using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbiesPanel : Panel
{
    [SerializeField] private TMP_InputField enterCodeIF;
    [SerializeField] private Button enterBT;
    
    protected override void Awake()
    {
        base.Awake();
        
        enterBT.onClick.AddListener(() => {
            LobbyManager.Instance.JoinLobbyByCode(enterCodeIF.text);
            PanelActivity.Instance.MoveTo(Panels.WaitingPanel);
        });
    }

    protected override void Start()
    {    
        base.Start();
    }
    protected override void OnSelectionPanel()
    {
        base.OnSelectionPanel();
    }
    protected override void OnDeselectionPanel()
    {
        base.OnDeselectionPanel();
    }
}