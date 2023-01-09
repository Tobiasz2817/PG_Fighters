using Unity.Netcode;
using UnityEngine;

public class PrepareGame : NetworkBehaviour
{
    public PreparedGameInterface preparedGameInterface;
    
    public override void OnNetworkSpawn() {
        if (!IsServer) return;

        PreparingGameClientRpc();
    }

    [ClientRpc]
    private void PreparingGameClientRpc() {
        preparedGameInterface.InvokePreparedGame();
    }
}
