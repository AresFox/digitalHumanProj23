using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera cameraFar;
    public Camera cameraNear;
    bool nearEnabled = true;

    void Start()
    {
        cameraFar.enabled = true;
        cameraNear.enabled = false;
    }

    public void ChangeCamera()
    {
        //Debug.Log("Ö»ÒòÄãÌ«ÃÀ");
        cameraFar.enabled = !nearEnabled;
        cameraNear.enabled = nearEnabled;
        nearEnabled = !nearEnabled;
    }

}
