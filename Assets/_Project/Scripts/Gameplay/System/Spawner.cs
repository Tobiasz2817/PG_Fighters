using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    private void Awake() {
        Instance = this;
    }

    #region Spawner without set positions

    public NetworkObject SpawnPlayer(ulong myId,GameObject playerPrefab) {
        NetworkObject networkObject = Instantiate(playerPrefab).GetComponent<NetworkObject>();
        networkObject.SpawnAsPlayerObject(myId);

        return networkObject;
    }
    public NetworkObject SpawnNetworkObject(GameObject playerPrefab) {
        NetworkObject networkObject = Instantiate(playerPrefab).GetComponent<NetworkObject>();
        networkObject.Spawn();

        return networkObject;
    }
    public GameObject SpawnObject(GameObject playerPrefab) {
        return Instantiate(playerPrefab);
    }

    #endregion

    #region Spawner with set positions

    public NetworkObject SpawnPlayer(ulong myId,GameObject playerPrefab, SpawnTransform spawnTransform) {
        NetworkObject networkObject = SpawnAndSetObjectPosition(playerPrefab, spawnTransform).GetComponent<NetworkObject>();
        networkObject.SpawnAsPlayerObject(myId);

        return networkObject;
    }
    public NetworkObject SpawnNetworkObject(GameObject playerPrefab, SpawnTransform spawnTransform) {
        NetworkObject networkObject = SpawnAndSetObjectPosition(playerPrefab, spawnTransform).GetComponent<NetworkObject>();
        networkObject.Spawn();

        return networkObject;
    }
    public GameObject SpawnObject(GameObject playerPrefab, SpawnTransform spawnTransform) {
        return SpawnAndSetObjectPosition(playerPrefab, spawnTransform);
    }
    
    #endregion
    
    private GameObject SpawnAndSetObjectPosition(GameObject prefab ,SpawnTransform spawnTransform) {
        GameObject spawnedObject = Instantiate(prefab);
        spawnedObject.transform.position = spawnTransform.position;         
        spawnedObject.transform.rotation = spawnTransform.rotaiton;
        spawnedObject.transform.localScale = spawnTransform.scale;

        return spawnedObject;
    } 
}
public struct SpawnTransform
{
    public Vector3 position;
    public Quaternion rotaiton;
    public Vector3 scale;
}