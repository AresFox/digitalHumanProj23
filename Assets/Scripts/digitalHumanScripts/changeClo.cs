using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeClo : MonoBehaviour
{
    int bhair1 = -1;
    public GameObject manGo;
    public GameObject[] hairArr = new GameObject[] { };
    public void changeHair(int num)
    {
        for(int i=0;i<hairArr.Length;i++)
        {
            if(hairArr[i]!=null)
            {
                if (i != num)
                {
                    hairArr[i].SetActive(false);
                }
                else
                {
                    hairArr[i].SetActive(true);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void ChangeEquipUnCombine(ref GameObject go, GameObject resgo)
    //{
    //    if (go != null)
    //    {
    //        GameObject.DestroyImmediate(go);
    //    }

    //    go = GameObject.Instantiate(resgo);
    //    go.Reset(mSkeleton);
    //    go.name = resgo.name;

    //    SkinnedMeshRenderer render = go.GetComponentInChildren<SkinnedMeshRenderer>();
    //    ShareSkeletonInstanceWith(render, mSkeleton);
    //}

    //// �������
    //public void ShareSkeletonInstanceWith(SkinnedMeshRenderer selfSkin, GameObject target)
    //{
    //    Transform[] newBones = new Transform[selfSkin.bones.Length];
    //    for (int i = 0; i < selfSkin.bones.GetLength(0); ++i)
    //    {
    //        GameObject bone = selfSkin.bones[i].gameObject;

    //        // Ŀ���SkinnedMeshRenderer.bones�����ֻ��Ŀ��mesh��صĹ���,Ҫ���Ŀ��ȫ������,����ͨ�����ҵķ�ʽ.
    //        newBones[i] = FindChildRecursion(target.transform, bone.name);
    //    }

    //    selfSkin.bones = newBones;
    //}

    //// �ݹ����
    //public Transform FindChildRecursion(Transform t, string name)
    //{
    //    foreach (Transform child in t)
    //    {
    //        if (child.name == name)
    //        {
    //            return child;
    //        }
    //        else
    //        {
    //            Transform ret = FindChildRecursion(child, name);
    //            if (ret != null)
    //                return ret;
    //        }
    //    }

    //    return null;
    //}

}




