using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
                //playIndex = 0;
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

    public void RunPythonScript()
    {
        Process p = new Process();
        string path = @"E:\mihoyo\nielian\AIModel\new_digital\run.py";
        p.StartInfo.FileName = @"D:\anaconda\Anaconda\envs\digitalhuman_train\python.exe";
        // python xxx.py
        //https://zhuanlan.zhihu.com/p/354760671
        p.StartInfo.Arguments = path;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.CreateNoWindow = true;

        p.Start();
        print("Python script is starting...");
        p.BeginOutputReadLine();
        p.OutputDataReceived += new DataReceivedEventHandler(ReceiveHandler);
        p.WaitForExit();

    }
    static void ReceiveHandler(object sender, DataReceivedEventArgs eventArg)
    {
        if (!string.IsNullOrEmpty(eventArg.Data))
        {
            print(eventArg.Data);
        }
    }

    public void RunExeFile()
    {
        //https://blog.csdn.net/u012719718/article/details/53358331
        // https://www.jianshu.com/p/9bf35dbdbf25
        string _exePathName = @"E:/mihoyo/nielian/AIModel/new_digital/dist/run.exe";
        string fileDirectory = @"E:/mihoyo/nielian/AIModel/new_digital/dist/";
        try {
            Process myprocess = new Process();  
            ProcessStartInfo startInfo = new ProcessStartInfo(_exePathName);  
            myprocess.StartInfo = startInfo;
            myprocess.StartInfo.WorkingDirectory = fileDirectory;
            myprocess.StartInfo.UseShellExecute = false;
            myprocess.StartInfo.CreateNoWindow = false;
            myprocess.Start();
            print("now process is start");
            // myprocess.BeginOutputReadLine();
            // myprocess.OutputDataReceived += new DataReceivedEventHandler(ReceiveHandler);
        } catch (Exception ex) {  
            UnityEngine.Debug.Log("出错原因：" + ex.Message);  
        }
    }
    
}
