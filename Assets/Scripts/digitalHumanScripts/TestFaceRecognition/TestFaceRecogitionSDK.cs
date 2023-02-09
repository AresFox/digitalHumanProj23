//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//using System.Runtime.InteropServices;  //[DllImport]所需要引入的命名空间
//using System;
//using System.IO;
//using System.Configuration;

//public class TestFaceRecogitionSDK : MonoBehaviour
//{
//    //[DllImport("libarcsoft_face")]  


//    public RawImage rawimage;
//    WebCamTexture webCamTexture;

//    public Text webCamDisplayText;

//    void Start()
//    {
//        GoWebCam01();  //初始化设备

//        InitEngines();

//        btnStartVideo_Click(new object(), new EventArgs());
//    }

//    //CAMERA 01 SELECT
//    public void GoWebCam01()
//    {
//        WebCamDevice[] cam_devices = WebCamTexture.devices;
//        // for debugging purposes, prints available devices to the console
//        for (int i = 0; i < cam_devices.Length; i++)
//        {
//            print("Webcam available: " + cam_devices[i].name);
//        }

//        webCamTexture = new WebCamTexture(cam_devices[0].name, 1280, 720, 30);
//        rawimage.texture = webCamTexture;
//        if (webCamTexture != null)
//        {
//            //webCamTexture.Play();
//            Debug.Log("Web Cam Connected : " + webCamTexture.deviceName + "\n");
//        }
//        webCamDisplayText.text = "Camera Type: " + cam_devices[0].name.ToString();
//    }

//    private void InitEngines()
//    {
//        try
//        {
//            webCamDisplayText.text += "测试";

//            //读取配置文件
//            //AppSettingsReader reader = new AppSettingsReader();
//            //rgbCameraIndex = (int)reader.GetValue("RGB_CAMERA_INDEX", typeof(int));
//            //irCameraIndex = (int)reader.GetValue("IR_CAMERA_INDEX", typeof(int));
//            //frMatchTime = (int)reader.GetValue("FR_MATCH_TIME", typeof(int));
//            //liveMatchTime = (int)reader.GetValue("LIVENESS_MATCH_TIME", typeof(int));

//            AppSettingsReader reader = new AppSettingsReader();
//            rgbCameraIndex = 0;
//            irCameraIndex = 1;
//            frMatchTime = 20;
//            liveMatchTime = 20;

//            int retCode = 0;
//            bool isOnlineActive = true;//true(在线激活) or false(离线激活)
//            try
//            {
//                if (isOnlineActive)
//                {
//                    #region 读取在线激活配置信息
//                    //string appId = (string)reader.GetValue("APPID", typeof(string));
//                    //string sdkKey64 = (string)reader.GetValue("SDKKEY64", typeof(string));
//                    //string sdkKey32 = (string)reader.GetValue("SDKKEY32", typeof(string));
//                    //string activeKey64 = (string)reader.GetValue("ACTIVEKEY64", typeof(string));
//                    //string activeKey32 = (string)reader.GetValue("ACTIVEKEY32", typeof(string));

//                    string appId = "";
//                    string sdkKey64 = "";
//                    string sdkKey32 = "";
//                    string activeKey64 = "";
//                    string activeKey32 = "";

//                    webCamDisplayText.text += "111111";

//                    //判断CPU位数
//                    var is64CPU = Environment.Is64BitProcess;
//                    if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(is64CPU ? sdkKey64 : sdkKey32) || string.IsNullOrWhiteSpace(is64CPU ? activeKey64 : activeKey32))
//                    {
//                        Debug.LogError(string.Format("请在App.config配置文件中先配置APP_ID和SDKKEY{0}、ACTIVEKEY{0}!", is64CPU ? "64" : "32"));
//                        //MessageBox.Show(string.Format("请在App.config配置文件中先配置APP_ID和SDKKEY{0}、ACTIVEKEY{0}!", is64CPU ? "64" : "32"));

//                        //System.Environment.Exit(0);
//                        Quit();
//                    }
//                    #endregion

//                    webCamDisplayText.text += "准备激活";

//                    //在线激活引擎    如出现错误，1.请先确认从官网下载的sdk库已放到对应的bin中，2.当前选择的CPU为x86或者x64
//                    retCode = imageEngine.ASFOnlineActivation(appId, is64CPU ? sdkKey64 : sdkKey32, is64CPU ? activeKey64 : activeKey32);

//                    webCamDisplayText.text += "激活完成";
//                }
//                else
//                {
//                    #region 读取离线激活配置信息
//                    string offlineActiveFilePath = (string)reader.GetValue("OfflineActiveFilePath", typeof(string));
//                    if (string.IsNullOrWhiteSpace(offlineActiveFilePath) || !File.Exists(offlineActiveFilePath))
//                    {
//                        string deviceInfo;
//                        retCode = imageEngine.ASFGetActiveDeviceInfo(out deviceInfo);
//                        if (retCode != 0)
//                        {
//                            Debug.LogError("获取设备信息失败，错误码:" + retCode);
//                            //MessageBox.Show("获取设备信息失败，错误码:" + retCode);
//                        }
//                        else
//                        {
//                            File.WriteAllText("ActiveDeviceInfo.txt", deviceInfo);
//                            Debug.LogError("获取设备信息成功，已保存到运行根目录ActiveDeviceInfo.txt文件，请在官网执行离线激活操作，将生成的离线授权文件路径在App.config里配置后再重新运行");
//                            //MessageBox.Show("获取设备信息成功，已保存到运行根目录ActiveDeviceInfo.txt文件，请在官网执行离线激活操作，将生成的离线授权文件路径在App.config里配置后再重新运行");
//                        }
//                        //System.Environment.Exit(0);
//                        Quit();
//                    }
//                    #endregion
//                    //离线激活
//                    retCode = imageEngine.ASFOfflineActivation(offlineActiveFilePath);
//                }
//                if (retCode != 0 && retCode != 90114)
//                {
//                    Debug.LogError("激活SDK失败,错误码:" + retCode);
//                    //MessageBox.Show("激活SDK失败,错误码:" + retCode);
//                    //System.Environment.Exit(0);
//                    Quit();
//                }

//                webCamDisplayText.text += retCode.ToString();
//            }
//            catch (Exception ex)
//            {
//                if (ex.Message.Contains("无法加载 DLL"))
//                {
//                    Debug.LogError("请将SDK相关DLL放入bin对应的x86或x64下的文件夹中!");
//                    //MessageBox.Show("请将SDK相关DLL放入bin对应的x86或x64下的文件夹中!");
//                }
//                else
//                {
//                    Debug.LogError("激活SDK失败,请先检查依赖环境及SDK的平台、版本是否正确!");
//                    //MessageBox.Show("激活SDK失败,请先检查依赖环境及SDK的平台、版本是否正确!");
//                }
//                //System.Environment.Exit(0);
//                Quit();
//            }

//            //初始化引擎
//            DetectionMode detectMode = DetectionMode.ASF_DETECT_MODE_IMAGE;
//            //Video模式下检测脸部的角度优先值
//            ASF_OrientPriority videoDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_ALL_OUT;
//            //Image模式下检测脸部的角度优先值
//            ASF_OrientPriority imageDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_ALL_OUT;
//            //最大需要检测的人脸个数
//            int detectFaceMaxNum = 6;
//            //引擎初始化时需要初始化的检测功能组合
//            int combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_AGE | FaceEngineMask.ASF_GENDER | FaceEngineMask.ASF_FACE3DANGLE | FaceEngineMask.ASF_IMAGEQUALITY | FaceEngineMask.ASF_MASKDETECT;
//            //初始化引擎，正常值为0，其他返回值请参考http://ai.arcsoft.com.cn/bbs/forum.php?mod=viewthread&tid=19&_dsign=dbad527e
//            retCode = imageEngine.ASFInitEngine(detectMode, imageDetectFaceOrientPriority, detectFaceMaxNum, combinedMask);
//            Console.WriteLine("InitEngine Result:" + retCode);
//            AppendText((retCode == 0) ? "图片引擎初始化成功!" : string.Format("图片引擎初始化失败!错误码为:{0}", retCode));
//            if (retCode != 0)
//            {
//                //禁用相关功能按钮
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }

//            //初始化视频模式下人脸检测引擎
//            DetectionMode detectModeVideo = DetectionMode.ASF_DETECT_MODE_VIDEO;
//            int combinedMaskVideo = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_FACELANDMARK;
//            retCode = videoEngine.ASFInitEngine(detectModeVideo, videoDetectFaceOrientPriority, detectFaceMaxNum, combinedMaskVideo);
//            AppendText((retCode == 0) ? "视频引擎初始化成功!" : string.Format("视频引擎初始化失败!错误码为:{0}", retCode));
//            if (retCode != 0)
//            {
//                //禁用相关功能按钮
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }

//            //RGB视频专用FR引擎
//            combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_LIVENESS | FaceEngineMask.ASF_MASKDETECT;
//            retCode = videoRGBImageEngine.ASFInitEngine(detectMode, videoDetectFaceOrientPriority, detectFaceMaxNum, combinedMask);
//            AppendText((retCode == 0) ? "RGB处理引擎初始化成功!" : string.Format("RGB处理引擎初始化失败!错误码为:{0}", retCode));
//            if (retCode != 0)
//            {
//                //禁用相关功能按钮
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }
//            //设置活体阈值
//            videoRGBImageEngine.ASFSetLivenessParam(thresholdRgb);

//            //IR视频专用FR引擎
//            combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_IR_LIVENESS;
//            retCode = videoIRImageEngine.ASFInitEngine(detectModeVideo, videoDetectFaceOrientPriority, detectFaceMaxNum, combinedMask);
//            AppendText((retCode == 0) ? "IR处理引擎初始化成功!\r\n" : string.Format("IR处理引擎初始化失败!错误码为:{0}\r\n", retCode));
//            if (retCode != 0)
//            {
//                //禁用相关功能按钮
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }
//            //设置活体阈值
//            videoIRImageEngine.ASFSetLivenessParam(thresholdRgb, thresholdIr);

//            initVideo();
//        }
//        catch (Exception ex)
//        {
//            LogUtil.LogInfo(GetType(), ex);
//            Debug.LogError("程序初始化异常,请在App.config中修改日志配置,根据日志查找原因!");
//            //MessageBox.Show("程序初始化异常,请在App.config中修改日志配置,根据日志查找原因!");

//            Quit();
//            //System.Environment.Exit(0);
//        }
//    }




//}
