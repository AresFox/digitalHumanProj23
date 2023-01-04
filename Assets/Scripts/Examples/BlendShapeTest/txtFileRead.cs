using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;
using UnityEngine.Assertions;

public class txtFileRead : MonoBehaviour
{
    /// <summary>
        /// 这个二维的List的每一行是一帧的数据,每一列是每一个BS的数据
        /// </summary>
        public List<List<double>> valueArray = new List<List<double>>();
    
        private int BSSize;  //每一帧包含BS的数量
        public int frameSize; //帧数
        [Header("对应文本文件的名字")]
        private string filename="BStxtFile1.txt";
        private void Start()
        {
            ReadBSIndexFile();
            ReadTxtFile(filename);
        }

        public void SetFilename(int index)
        {
            switch (index)
            {
                case 0:
                    filename = "BStxtFile1.txt";
                    break;
                case 1:
                    filename = "test_sentence.txt";
                    break;
                case 2:
                    filename = "zw2.txt";
                    break;
            }
            ReadTxtFile(filename);
        }
    
        /// <summary>
        /// 读取所有的BS名字,确认共有多少个BS
        /// </summary>
        private void ReadBSIndexFile()
        {
            string path = Application.dataPath + "/readFiles/txtFiles/expression_index.txt";
            string[] strs = File.ReadAllLines(path);
            BSSize = strs.Length;
            print(BSSize);
        }
    
        /// <summary>
        /// 传入Assets文件夹下的子路径/readFiles/txtFiles/里的txt文件名
        /// </summary>
        /// <param name="filename"></param>
        public void ReadTxtFile(string filename)
        {
            valueArray.Clear();
            string path = Application.dataPath + "/readFiles/txtFiles/" + filename;
            string[] strs = File.ReadAllLines(path);
            frameSize = strs.Length;
            foreach (string item in strs)
            {
                string tmpItem = item;
                List<double> tmpArray = new List<double>();
                string[] splitValues = tmpItem.Split(' ');
                Assert.AreEqual(splitValues.Length,BSSize);
                foreach (var word in splitValues)
                {
                    string tmpWord = word;
                    double value = double.Parse(tmpWord);
                    tmpArray.Add(value);
                }
                valueArray.Add(tmpArray);
            }
            print("=========txt文本文件读取完毕======");
            print("该文本文件一共包含"+frameSize.ToString()+"帧的内容");
            print("共计要处理的BS数量为:"+BSSize.ToString());
        }
}
