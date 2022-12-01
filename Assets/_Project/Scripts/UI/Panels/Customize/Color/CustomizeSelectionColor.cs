using UnityEngine;

public class CustomizeSelectionColor : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        CustomizeSelectionPrefab.OnCustomizeSelectionColor += EquipColor;
    }

    private void EquipColor(GameObject prefab)
    {
        meshRenderer.material.mainTexture = prefab.GetComponent<SkinnedMeshRenderer>().material.mainTexture;
    }
}