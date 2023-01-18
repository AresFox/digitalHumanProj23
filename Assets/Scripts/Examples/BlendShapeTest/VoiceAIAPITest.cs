using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

public class VoiceAIAPITest : MonoBehaviour
{
    private Dictionary<string, double> voiceBlendShapeDict; //存储每个BS在每一帧的数据，key是BS的名字，value是每一帧的数据
    [Header("BS索引文件的路径，可以自行指定BS索引文件或者使用默认的文件BSIndexDefault.txt")]
    public string voiceBlendshapeIndexFilePath;  //指定BS索引文件的路径

    private string[] BSTrainNames;
    [Header("是否需要打印出调试信息？（方便调试使用）")]
    public bool showLogMsg = false;
    private int BSIndexSize;  //每一帧应该包含BS的数量
    private int frameSize; //对应的wav格式文件训练结果一共有多少帧
    
    private List<List<double>> valueArray = new List<List<double>>();  //存储每一帧的每种BS的数值
    
    public void ReadTxtFile(string filename)   //已经训练完了的文件
    {
        valueArray.Clear();
        string path = Application.dataPath + filename;
        string[] strs = File.ReadAllLines(path);
        frameSize = strs.Length;
        if(frameSize==0) Debug.LogError("训练得到的结果存在问题！请检查输入音频路径和音频源是否存在损坏！");
        foreach (string item in strs)
        {
            string tmpItem = item;
            List<double> tmpArray = new List<double>();
            string[] splitValues = tmpItem.Split(' ');
            Assert.AreEqual(splitValues.Length,BSIndexSize);
            foreach (var word in splitValues)
            {
                string tmpWord = word;
                double value = double.Parse(tmpWord);
                tmpArray.Add(value);
            }
            valueArray.Add(tmpArray);  //valueArray的每一行是每一帧的数据，每一列是每一种BS的相关数据
        }

        if (showLogMsg)
        {
            Debug.Log("打印训练得到的结果的前两行数据");
            for(int i=0;i<2;i++)
                for(int j=0;j<BSIndexSize;j++)
                    Debug.Log(valueArray[i][j]);
        }
    }

    /// <summary>
    /// 分析音频所在位置，并给出所有BS的名字和对应的参数，以便于在后续的调用当中使用。
    /// </summary>
    /// <param name="filePath">Assets文件夹下的路径，示例：/readFiles/txtFiles/testFile.wav</param>
    /// <returns></returns>
    public Dictionary<string, double> AnalyzeVoice(string filePath)
    {
        filePath = "/readFiles/txtFiles/testzhongli.txt"; //todo: 测试使用，后面调用API的时候用户只需要传入正确的filePath就行
        //首先，对wav格式文件进行处理，用Python来运行程序,直接返回输出的Dict以便于后续使用
        if(voiceBlendshapeIndexFilePath==null) Debug.LogError("需要指定Blendshape的Index文件所在的路径！");
        int BStotalSize = AnalyzeBlendshapeFileSize(voiceBlendshapeIndexFilePath);
        ReadTxtFile(filePath);

        return null;
    }

    /// <summary>
    /// 分析Index文件当中共有多少个BS，返回值是共计训练得到的BS数量
    /// </summary>
    /// <param name="fileIndexPath"></param>
    /// <returns></returns>
    public int AnalyzeBlendshapeFileSize(string fileIndexPath)
    {
        string path = Application.dataPath + fileIndexPath;
        string[] strs = File.ReadAllLines(path);
        if (strs.Length == 0)
        {
            Debug.LogError("Blendshape的Index文件存在问题！请检查文件的路径填写是否有误，或者文件内容是否不符合格式!");
        }

        BSTrainNames = new string[strs.Length];
        for (int i = 0; i < strs.Length; i++)
            BSTrainNames[i] = strs[i].Split(',')[1].Replace(".obj","");
        
        if (showLogMsg)
        {
            Debug.Log("========================================");
            Debug.Log("======Debug.log：打印所有的BSindex文件中的BS名字：======");
            for (int i = 0; i < strs.Length; i++)
                Debug.Log(BSTrainNames[i]);
            Debug.Log("总的BS的数量："+strs.Length);
        }

        BSIndexSize = strs.Length;
        return BSIndexSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        voiceBlendShapeDict = AnalyzeVoice(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
