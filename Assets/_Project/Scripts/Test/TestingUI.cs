using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingUI : MonoBehaviour
{
    private SkinnedMeshRenderer sk;
    void Start()
    {
        sk = GetComponent<SkinnedMeshRenderer>();
        foreach (var transform in GetComponentsInChildren<Transform>())
        {
            if (transform.name == "RigPelvis")
                sk.rootBone = GetComponentInParent<Transform>();
        }
        sk.GetPreviousVertexBuffer();
    }
}
