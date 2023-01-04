using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BSSliderSwitch : MonoBehaviour
{
    private Slider[] BSSliders;
    private Text[] names;
    private GameObject[] BSObjects;
    public GameObject digitalPeopleShape;
    private BlendShapeExample_1 blendShapeControlScript;
    public GameObject sliderPrefab;
    public int wantNumber;
    void Start()
    {
        BSObjects = new GameObject[40];
        names = new Text[40];
        BSSliders = new Slider[40];
        GameObject root = GameObject.Find("ContentForBS");
        for (int i = 0; i < wantNumber; i++)
        {
            GameObject mChild = Instantiate(sliderPrefab);
            mChild.transform.parent = root.transform;
        }

        blendShapeControlScript = digitalPeopleShape.GetComponent<BlendShapeExample_1>();
        if (!blendShapeControlScript) Debug.LogError("there is no scipt");
        
        
        for(int i = 0; i < wantNumber; i++)
        {
            Debug.Log("Slider_" + (i + 1).ToString());
            BSObjects[i] = root.transform.GetChild(i).gameObject;
            if (BSObjects[i])
            {
                BSSliders[i] = BSObjects[i].GetComponentInChildren<Slider>();
                names[i] = BSObjects[i].GetComponentInChildren<Text>();
                if (!(BSSliders[i] && names[i]))
                {
                    Debug.LogError("Something goes wrong");
                }
            }
            
        }
        
        for(int i = 0; i < wantNumber; i++)
        {
            int tmpIndex = i; //https://forum.unity.com/threads/solved-adding-listeners-with-for-loop-issues.760862/
            BSSliders[tmpIndex].onValueChanged.AddListener(delegate { OnValueChange(tmpIndex); });
        }

        if (blendShapeControlScript)
        {
            blendShapeControlScript.ChangeName(names, wantNumber);
        }

    }

    void OnValueChange(int index)
    {
        //Debug.Log(index);
        //Debug.Log(BSSliders[index].value);
        int idx = index;
        float value = BSSliders[idx].value;
        blendShapeControlScript.ChangeBS(idx, value);
    }
}
