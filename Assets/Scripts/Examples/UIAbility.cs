using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbility : MonoBehaviour
{
    public Button changeCamera;
    public GameObject gameManager;
    private CameraSwitch cameraSwitchScript;
    public GameObject BSSlider;
    private BSSliderSwitch sliderSwitch;
    // Start is called before the first frame update
    void Start()
    {
        cameraSwitchScript = gameManager.GetComponent<CameraSwitch>();
        if (!cameraSwitchScript)
        {
            Debug.LogError("There is no CameraSwitch Script in GameManager!");
        }
        sliderSwitch = BSSlider.GetComponent<BSSliderSwitch>();
        if (!sliderSwitch)
        {
            Debug.LogError("There is no sliderSwitch Script in Canvas!");
        }
    }

    public void OnChangeCameraBtnClick()
    {
        if (cameraSwitchScript)
        {
            cameraSwitchScript.ChangeCamera();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
