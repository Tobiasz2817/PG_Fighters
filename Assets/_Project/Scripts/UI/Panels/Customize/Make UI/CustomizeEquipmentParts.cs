using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                    customizePrefab.SetupChild(new CustomizeSelection() {customizePrefab = element.prefab, index = x}, element.imagePrefab);
                    CustomizeCharacterEquipmentData.Instance.SetElementsCustomizedCharacter(x,element.prefab);
                    x++;
                }
            }
    }

    public void SaveChanges()
    {
        Dictionary<string,List<int>> tmp = new Dictionary<string, List<int>>();
        var customizePrefabs = GetComponentsInChildren<CustomizePrefab>();
        foreach (var customizePrefab in customizePrefabs)
        {
            if(tmp.ContainsKey(customizePrefab.Content))
                tmp[customizePrefab.Content].Add(customizePrefab.IndexPrefab);
            else
                tmp.Add(customizePrefab.Content,new List<int>() {customizePrefab.IndexPrefab});
        }

        foreach (var dict in tmp)
            CustomizeCharacterEquipmentData.Instance.SetCurrentEquipment(new CustomizeEquipmentPart() {head = dict.Key, indexList = dict.Value});
    }
}
