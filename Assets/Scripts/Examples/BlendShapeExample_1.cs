using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendShapeExample_1 : MonoBehaviour
{
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    float blendOne = 0f;
    float blendTwo = 0f;
    float blendSpeed = 1f;
    bool blendOneFinished = false;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;
        Debug.Log("blendShapeCount...");
        Debug.Log(blendShapeCount);
    }

    public void ChangeName(Text[] text,int number)
    {
        int gap = 1;
        for(int i = 0; i < number; i++)
        {
            string tmpname = skinnedMesh.GetBlendShapeName(i * gap + 0).Replace("Genesis8Male__","");
            text[i].text = tmpname;
        }
    }

    public void ChangeBS(int index,float value)
    {
        int gap = 1;
        skinnedMeshRenderer.SetBlendShapeWeight(index*gap+0, value);
    }

    //void Update()
    //{
    //    if (blendShapeCount > 2)
    //    {
    //        if (blendOne < 100f)
    //        {
    //            skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        else
    //        {
    //            blendOneFinished = true;
    //        }

    //        if (blendOneFinished == true && blendTwo < 100f)
    //        {
    //            skinnedMeshRenderer.SetBlendShapeWeight(1, blendTwo);
    //            blendTwo += blendSpeed;
    //        }
    //    }
    //}

}
