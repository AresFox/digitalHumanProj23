using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 
public class changeSk : MonoBehaviour
{

    private SkinnedMeshRenderer oldSmr = null;
    private SkinnedMeshRenderer newSmr = null;

    private Object oldObj = null;
    private Object newObj = null;

    private GameObject oldInstance = null;
    private GameObject newInstance = null;

    //自动生成UI
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "ChangeHair"))
        {
            ChangeHairWithSke(1);
        }

        if (GUI.Button(new Rect(10, 50, 100, 30), "ChangeHair2"))
        {
            ChangeHairWithSke(2);
        }

        if (GUI.Button(new Rect(10, 90, 100, 30), "default")) 
        {
            ChangeHairWithSke(0);
        }

        if (GUI.Button(new Rect(110, 10, 100, 30), "ChangePants"))
        {
            ChangePantsWithSke(1);
        }
    }


    void ChangeHairWithSke(int hairNum)
    {
        //加载替换对象的资源文件
        if(hairNum==1)
            newObj = Resources.Load("Prefab/hairHiraku_Pre1");

        if (hairNum == 2)
            newObj = Resources.Load("Prefab/hairPre2");

        if(hairNum==0)
        {
            newObj = Resources.Load("Prefab/nullPre1");
        }    

        newInstance = Instantiate(newObj) as GameObject;

        oldSmr = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        newSmr = newInstance.GetComponentInChildren<SkinnedMeshRenderer>();

        Transform[] oldBones = gameObject.GetComponentsInChildren<Transform>();
        //Transform[] oldBones = oldSmr.bones;              //模型会出现错乱
        Debug.Log("oldBones.Length: " + oldBones.Length);
        Transform[] newBones = newSmr.bones;
        Debug.Log("newBones.Length: " + newBones.Length);

        //对骨骼进行重新排序
        List<Transform> bones = new List<Transform>();
        foreach (Transform bone in newBones)
        {
            foreach (Transform oldBone in oldBones)
            {
                if (bone != null && oldBone != null)
                {
                    if (bone.name != oldBone.name)
                    {
                        continue;
                    }
                    bones.Add(oldBone);
                }
            }
        }
        //替换Mesh数据
        oldSmr.bones = bones.ToArray();
        oldSmr.sharedMesh = newSmr.sharedMesh;
        oldSmr.sharedMaterial = newSmr.sharedMaterial;


        //删除无用的对象
        GameObject.DestroyImmediate(newInstance);
        GameObject.DestroyImmediate(newSmr);

        //oldSmr.bones = bones.ToArray();
        //oldSmr.sharedMesh = newSmr.sharedMesh;
        //oldSmr.sharedMaterial = newSmr.sharedMaterial;
    }

    void ChangePantsWithSke(int hairNum)
    {
        //加载替换对象的资源文件
        //if (hairNum == 1)
            //newObj = Resources.Load("Prefab/manPnatsPre1");
            newObj = Resources.Load("Prefab/manPnatsW2");
        if (newObj) Debug.Log("PANTSpRE");

        //if (hairNum == 2)
        //    newObj = Resources.Load("Prefab/hairPre2");

        //if (hairNum == 0)
        //{
        //    newObj = Resources.Load("Prefab/nullPre1");
        //}

        newInstance = Instantiate(newObj) as GameObject;

        GameObject goID = GameObject.Find("WindwalkerPants_9503.Shape");//lllLLL
        //GameObject goID = GameObject.Find("lllLLL");//lllLLL

        //if (goID) Debug.Log("PANTS");
        //GameObject goold = gameObject.transform.GetChild("WindwalkerPants_9503.Shape");
        //oldSmr = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        oldSmr = goID.GetComponentInChildren<SkinnedMeshRenderer>();

        newSmr = newInstance.GetComponentInChildren<SkinnedMeshRenderer>();

        Transform[] oldBones = gameObject.GetComponentsInChildren<Transform>();
        //Transform[] oldBones = oldSmr.bones;              //模型会出现错乱
        Debug.Log("oldBones.Length: " + oldBones.Length);
        Transform[] newBones = newSmr.bones;
        Debug.Log("newBones.Length: " + newBones.Length);

        //对骨骼进行重新排序
        List<Transform> bones = new List<Transform>();
        foreach (Transform bone in newBones)
        {
            foreach (Transform oldBone in oldBones)
            {
                if (bone != null && oldBone != null)
                {
                    if (bone.name != oldBone.name)
                    {
                        continue;
                    }
                    bones.Add(oldBone);
                }
            }
        }
        //替换Mesh数据
        oldSmr.bones = bones.ToArray();
        oldSmr.sharedMesh = newSmr.sharedMesh;
        oldSmr.sharedMaterial = newSmr.sharedMaterial;


        //删除无用的对象
        GameObject.DestroyImmediate(newInstance);
        GameObject.DestroyImmediate(newSmr);

        //oldSmr.bones = bones.ToArray();
        //oldSmr.sharedMesh = newSmr.sharedMesh;
        //oldSmr.sharedMaterial = newSmr.sharedMaterial;
    }
}