using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSChange : MonoBehaviour
{
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    private int[] BSIndex = new int[]
    {
        36, 35, 28, 28, 34, 33, 32, 31, 30, 29, 22, 21, 20,
        19, 17, 16, 15, 14, 18, 13, 12, 11, 10, 9, 7, 3, 2, 1, 0, 42, 41, 40, 39, 38, 37, 24, 23, 4
    };  //BS的索引值

    private int BSSize;

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
        BSSize = BSIndex.Length;
        Debug.Log("BSSIZE.....");
        Debug.Log(BSSize);
    }
    
    /// <summary>
    /// 修改对应的BS的值,传入的参数是训练得到的txt文件的每一行
    /// </summary>
    /// <param name="BSValuegroups"></param>
    public void ChangeBSgroups(List<double> BSValuegroups)
    {
        for (int i = 0; i < BSSize; i++)
        {
            float tmpValue = (float)(BSValuegroups[i]*100);
            // Debug.Log("i===");
            // Debug.Log(i);
            // Debug.Log("value");
            // Debug.Log(tmpValue);
            
            skinnedMeshRenderer.SetBlendShapeWeight(BSIndex[i], tmpValue);
        }
    }

    /// <summary>
    /// 重置所有的相关BS
    /// </summary>
    public void ResetAllBS()
    {
        for (int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(i, 0);  
        }
    }
    
}
