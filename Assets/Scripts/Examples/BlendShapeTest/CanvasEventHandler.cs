using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasEventHandler : MonoBehaviour
{
    private List<List<double>> BSValues = new List<List<double>>();
    private bool startPlay;
    private int frameSize;
    private txtFileRead fileInfo;
    public GameObject digitalPeopleShape;
    private BSChange bsChange;
    private int playIndex = 0;
    private AudioSource music;

    public AudioClip[] audioclips;
    
    void Start()
    {
        Application.targetFrameRate = 60;  //固定程序的帧率为60帧
        
        startPlay = false;
        fileInfo = this.gameObject.GetComponent<txtFileRead>();
        if(!fileInfo) Debug.LogError("no ref script");
        frameSize = fileInfo.frameSize;
        BSValues = fileInfo.valueArray;
        bsChange = digitalPeopleShape.gameObject.GetComponent<BSChange>();
        if(!bsChange) Debug.LogError("no ref script");
        music = digitalPeopleShape.gameObject.GetComponent<AudioSource>();
        
        playIndex = 0;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (startPlay)
        {
            bsChange.ChangeBSgroups(BSValues[playIndex]);
            playIndex++;
            if (playIndex == frameSize)
            {
                startPlay = false;
                Debug.Log("end animation");
            }
            
        }
    }
    
    public void OnStartBtnClick()
    {
        startPlay = true;
        music.Play();
        Application.targetFrameRate = 60;  //固定程序的帧率为60帧
        playIndex = 0;
        print("hello world");
    }

    public void LoadTxtAndAudioFile(int index)
    {
        startPlay = false;
        bsChange.ResetAllBS();
        fileInfo.SetFilename(index);
        frameSize = fileInfo.frameSize;
        playIndex = 0;
        SetMusic(index);
    }
    // Start is called before the first frame update

    private void SetMusic(int index)
    {
        if (!music.isPlaying)
        {
            AudioClip clip = audioclips[index];
            music.clip = clip;
        }
        else
        {
            music.Stop();
        }
    }

    
}
