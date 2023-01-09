using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

public class PlayerCustomizeEquipment : NetworkBehaviour
{
    private Dictionary<string, Transform> characterContetns = new Dictionary<string,Transform>();

    [SerializeField] private Transform body;

    public override void OnNetworkSpawn() {
        characterContetns = FindContents();
        if (!IsOwner) return;
        
        foreach (var customize in CustomizeCharacterEquipmentData.Instance.GetCustomizeSelections())
            if (customize.index != -1) 
                SetEquipmentServerRpc(customize.contentName,customize.index);
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetEquipmentServerRpc(string content,int index) {
        SetEquipmentClientRpc(content,index);
    }
    
    [ClientRpc]
    private void SetEquipmentClientRpc(string content,int index) {
        if(content != "+ Color")
            Instantiate(CustomizeCharacterEquipmentData.Instance.GetCustomizePrefab(index), characterContetns[content]);
        else {
            var color = Instantiate(CustomizeCharacterEquipmentData.Instance.GetCustomizePrefab(index));
            characterContetns[content].GetComponent<SkinnedMeshRenderer>().material.mainTexture =
                color.GetComponent<SkinnedMeshRenderer>().material.mainTexture;
            Destroy(color);
        }
    }   

    private Dictionary<string, Transform> FindContents() {
        Dictionary<string, Transform> tmp = new Dictionary<string, Transform>();
        var compo = body.transform.GetComponentsInChildren<Transform>();

        foreach (var child in compo)
            foreach (var contentKey in CustomizeCharacterEquipmentData.Instance.GetHeaders())
                if (child.name == contentKey) 
                    if(!tmp.ContainsKey(contentKey))
                        tmp.Add(contentKey, child);
        return tmp;
    }
}
