using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Testtt : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    private PlayerData _playerData;

    public static Action OnLoad;
    public static Action OnSave;

    private void Awake()
    {
        _playerInput.actions["Load"].performed += Load;
        _playerInput.actions["Save"].performed -= Save;

        OnLoad += LoadData;
        OnSave += SaveData;
    }

    private void Save(InputAction.CallbackContext obj)
    {
        OnLoad?.Invoke();
    }

    private void Load(InputAction.CallbackContext obj)
    {
        OnSave?.Invoke();
    }

    public void LoadData()
    {
        var playerData = SaveManager.LoadData<PlayerData>();
        Debug.Log(playerData.damage);
        Debug.Log(playerData.name);
    }
    public void SaveData()
    {
        PlayerData playerData = new PlayerData() {damage = 5, name = "Elo"};
        SaveManager.SaveData(playerData);
    }
}

public struct PlayerData
{
    public int damage;
    public string name;
}
