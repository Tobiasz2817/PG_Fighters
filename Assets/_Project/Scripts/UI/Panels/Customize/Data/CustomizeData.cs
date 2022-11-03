using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeData : MonoBehaviour
{
    #region Input Data
    [Serializable]
    public class MainPart
    {
        public string nameMainPart; 
        public List<SecoundPart> secoundPartList;
    }
    [Serializable]
    public class SecoundPart
    {
        public string nameFirstPart;
        public List<Element> partList;
    }

    [Serializable]
    public class Element
    {
        public GameObject prefab;
        public Sprite imagePrefab;
    }

    private readonly List<MainPart> customizeLists = new List<MainPart>();
    #endregion

    public List<MainPart> GetCustomizeList()
    {
        return customizeLists;
    }
}
