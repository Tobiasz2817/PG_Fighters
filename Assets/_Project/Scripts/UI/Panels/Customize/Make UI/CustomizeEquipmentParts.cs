using System.Collections.Generic;
using UnityEngine;

public class CustomizeEquipmentParts : MonoBehaviour
{
    [SerializeField] 
    private CustomizeData _customizeData;

    [SerializeField]
    private GameObject _customizePrefab;
    
    void Start()
    {
        InstancesChilds();
    }

    private void InstancesChilds()
    {
        int x = 0;
        foreach (var mainPart in _customizeData.GetCustomizeList())
        foreach (var secoundPart in mainPart.secoundPartList)
        {
            var tmp = Instantiate(_customizePrefab, transform);
            var customizePrefab = tmp.GetComponent<CustomizePrefab>();
            customizePrefab.SetupPrefab(secoundPart.nameFirstPart,mainPart.nameMainPart);

            foreach (var element in secoundPart.partList)
            {
                customizePrefab.SetupChild(new CustomizeSelection() {customizePrefab = element.prefab, index = x},element.imagePrefab);
                CustomizeCharacterData.Instance.SetElementsCustomizedCharacter(x,element.prefab);
                x++;
            }

        }
    }

    public void SaveChanges()
    {
        foreach (var prefab in GetComponentsInChildren<CustomizePrefab>())
        {
            CustomizeCharacterData.Instance.SetCurrentEquipment(prefab.Content,prefab.IndexPrefab);
        }
    }
}
