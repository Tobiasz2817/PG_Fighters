using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeColor : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer customizeMaterial;

    /*private int i = 0;
    private int count;

    private void Start()
    {
        count = CustomizeCharacterData.Instance.GetCountCharacterTextures();
        SetCharacterColor(i);
    }
    public void SwitchColor(Side side)
    {
        var indexTexture = ValidateIndexer(side);
        SetCharacterColor(indexTexture);
        SetSelectedTexture(indexTexture);
    }

    private int ValidateIndexer(Side side)
    {
        switch (side)
        {
            case Side.Left:
                i--;
                break;
            case Side.Right:
                i++;
                break;
        }
        
        if (i < 0) i = count - 1;
        if (i > count - 1) i = 0;

        return i;
    }

    private void SetCharacterColor(int i)
    {
        customizeMaterial.material.mainTexture = CustomizeCharacterData.Instance.GetTexture(i);
    }

    private void SetSelectedTexture(int i)
    {
        CustomizeCharacterData.Instance.SelectedTexture = i;
    }*/
}
