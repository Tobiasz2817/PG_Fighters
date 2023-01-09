using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsReaperedGame { set; get; }
    public bool IsStarted { set; get; }
    public bool IsOver { set; get; }
    
    public static event Action OnGameStart;
    public static event Action OnGameStop;
    
    private void Awake() {
        Instance = this;
    }

    private void OnEnable() {
        PreparedGameInterface.OnInterfacePrepared += EnableGameState;
    }

    private void OnDisable() {
        PreparedGameInterface.OnInterfacePrepared -= EnableGameState;
    }

    private void EnableGameState() {
        IsStarted = true;
        OnGameStart?.Invoke();
        Debug.Log("Game started");
    }
}
