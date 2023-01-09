using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Samples.Utilities;
using Unity.Netcode;
using UnityEngine;

public class PlayerSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject robotPrefab;
    [SerializeField] private Transform[] points;
    
    public override void OnNetworkSpawn() {
        if (IsServer)
            foreach (var client in NetworkManager.Singleton.ConnectedClients) 
                SpawnRobot(client.Key);
    }

    private void SpawnRobot(ulong id) {
        SpawnTransform spawnTransform = new SpawnTransform {
            position = points[id].position,
            rotaiton = points[id].rotation,
            scale = robotPrefab.transform.localScale
        };
        
        Spawner.Instance.SpawnPlayer(id, robotPrefab,spawnTransform);
    }
}
