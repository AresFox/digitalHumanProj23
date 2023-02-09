//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//using System.Runtime.InteropServices;  //[DllImport]����Ҫ����������ռ�
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
//        GoWebCam01();  //��ʼ���豸

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
//            webCamDisplayText.text += "����";

//            //��ȡ�����ļ�
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
//            bool isOnlineActive = true;//true(���߼���) or false(���߼���)
//            try
//            {
//                if (isOnlineActive)
//                {
//                    #region ��ȡ���߼���������Ϣ
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

//                    //�ж�CPUλ��
//                    var is64CPU = Environment.Is64BitProcess;
//                    if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(is64CPU ? sdkKey64 : sdkKey32) || string.IsNullOrWhiteSpace(is64CPU ? activeKey64 : activeKey32))
//                    {
//                        Debug.LogError(string.Format("����App.config�����ļ���������APP_ID��SDKKEY{0}��ACTIVEKEY{0}!", is64CPU ? "64" : "32"));
//                        //MessageBox.Show(string.Format("����App.config�����ļ���������APP_ID��SDKKEY{0}��ACTIVEKEY{0}!", is64CPU ? "64" : "32"));

//                        //System.Environment.Exit(0);
//                        Quit();
//                    }
//                    #endregion

//                    webCamDisplayText.text += "׼������";

//                    //���߼�������    ����ִ���1.����ȷ�ϴӹ������ص�sdk���ѷŵ���Ӧ��bin�У�2.��ǰѡ���CPUΪx86����x64
//                    retCode = imageEngine.ASFOnlineActivation(appId, is64CPU ? sdkKey64 : sdkKey32, is64CPU ? activeKey64 : activeKey32);

//                    webCamDisplayText.text += "�������";
//                }
//                else
//                {
//                    #region ��ȡ���߼���������Ϣ
//                    string offlineActiveFilePath = (string)reader.GetValue("OfflineActiveFilePath", typeof(string));
//                    if (string.IsNullOrWhiteSpace(offlineActiveFilePath) || !File.Exists(offlineActiveFilePath))
//                    {
//                        string deviceInfo;
//                        retCode = imageEngine.ASFGetActiveDeviceInfo(out deviceInfo);
//                        if (retCode != 0)
//                        {
//                            Debug.LogError("��ȡ�豸��Ϣʧ�ܣ�������:" + retCode);
//                            //MessageBox.Show("��ȡ�豸��Ϣʧ�ܣ�������:" + retCode);
//                        }
//                        else
//                        {
//                            File.WriteAllText("ActiveDeviceInfo.txt", deviceInfo);
//                            Debug.LogError("��ȡ�豸��Ϣ�ɹ����ѱ��浽���и�Ŀ¼ActiveDeviceInfo.txt�ļ������ڹ���ִ�����߼�������������ɵ�������Ȩ�ļ�·����App.config�����ú�����������");
//                            //MessageBox.Show("��ȡ�豸��Ϣ�ɹ����ѱ��浽���и�Ŀ¼ActiveDeviceInfo.txt�ļ������ڹ���ִ�����߼�������������ɵ�������Ȩ�ļ�·����App.config�����ú�����������");
//                        }
//                        //System.Environment.Exit(0);
//                        Quit();
//                    }
//                    #endregion
//                    //���߼���
//                    retCode = imageEngine.ASFOfflineActivation(offlineActiveFilePath);
//                }
//                if (retCode != 0 && retCode != 90114)
//                {
//                    Debug.LogError("����SDKʧ��,������:" + retCode);
//                    //MessageBox.Show("����SDKʧ��,������:" + retCode);
//                    //System.Environment.Exit(0);
//                    Quit();
//                }

//                webCamDisplayText.text += retCode.ToString();
//            }
//            catch (Exception ex)
//            {
//                if (ex.Message.Contains("�޷����� DLL"))
//                {
//                    Debug.LogError("�뽫SDK���DLL����bin��Ӧ��x86��x64�µ��ļ�����!");
//                    //MessageBox.Show("�뽫SDK���DLL����bin��Ӧ��x86��x64�µ��ļ�����!");
//                }
//                else
//                {
//                    Debug.LogError("����SDKʧ��,���ȼ������������SDK��ƽ̨���汾�Ƿ���ȷ!");
//                    //MessageBox.Show("����SDKʧ��,���ȼ������������SDK��ƽ̨���汾�Ƿ���ȷ!");
//                }
//                //System.Environment.Exit(0);
//                Quit();
//            }

//            //��ʼ������
//            DetectionMode detectMode = DetectionMode.ASF_DETECT_MODE_IMAGE;
//            //Videoģʽ�¼�������ĽǶ�����ֵ
//            ASF_OrientPriority videoDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_ALL_OUT;
//            //Imageģʽ�¼�������ĽǶ�����ֵ
//            ASF_OrientPriority imageDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_ALL_OUT;
//            //�����Ҫ������������
//            int detectFaceMaxNum = 6;
//            //�����ʼ��ʱ��Ҫ��ʼ���ļ�⹦�����
//            int combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_AGE | FaceEngineMask.ASF_GENDER | FaceEngineMask.ASF_FACE3DANGLE | FaceEngineMask.ASF_IMAGEQUALITY | FaceEngineMask.ASF_MASKDETECT;
//            //��ʼ�����棬����ֵΪ0����������ֵ��ο�http://ai.arcsoft.com.cn/bbs/forum.php?mod=viewthread&tid=19&_dsign=dbad527e
//            retCode = imageEngine.ASFInitEngine(detectMode, imageDetectFaceOrientPriority, detectFaceMaxNum, combinedMask);
//            Console.WriteLine("InitEngine Result:" + retCode);
//            AppendText((retCode == 0) ? "ͼƬ�����ʼ���ɹ�!" : string.Format("ͼƬ�����ʼ��ʧ��!������Ϊ:{0}", retCode));
//            if (retCode != 0)
//            {
//                //������ع��ܰ�ť
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }

//            //��ʼ����Ƶģʽ�������������
//            DetectionMode detectModeVideo = DetectionMode.ASF_DETECT_MODE_VIDEO;
//            int combinedMaskVideo = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_FACELANDMARK;
//            retCode = videoEngine.ASFInitEngine(detectModeVideo, videoDetectFaceOrientPriority, detectFaceMaxNum, combinedMaskVideo);
//            AppendText((retCode == 0) ? "��Ƶ�����ʼ���ɹ�!" : string.Format("��Ƶ�����ʼ��ʧ��!������Ϊ:{0}", retCode));
//            if (retCode != 0)
//            {
//                //������ع��ܰ�ť
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }

//            //RGB��Ƶר��FR����
//            combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_LIVENESS | FaceEngineMask.ASF_MASKDETECT;
//            retCode = videoRGBImageEngine.ASFInitEngine(detectMode, videoDetectFaceOrientPriority, detectFaceMaxNum, combinedMask);
//            AppendText((retCode == 0) ? "RGB���������ʼ���ɹ�!" : string.Format("RGB���������ʼ��ʧ��!������Ϊ:{0}", retCode));
//            if (retCode != 0)
//            {
//                //������ع��ܰ�ť
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }
//            //���û�����ֵ
//            videoRGBImageEngine.ASFSetLivenessParam(thresholdRgb);

//            //IR��Ƶר��FR����
//            combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_IR_LIVENESS;
//            retCode = videoIRImageEngine.ASFInitEngine(detectModeVideo, videoDetectFaceOrientPriority, detectFaceMaxNum, combinedMask);
//            AppendText((retCode == 0) ? "IR���������ʼ���ɹ�!\r\n" : string.Format("IR���������ʼ��ʧ��!������Ϊ:{0}\r\n", retCode));
//            if (retCode != 0)
//            {
//                //������ع��ܰ�ť
//                //ControlsEnable(false, chooseMultiImgBtn, matchBtn, btnClearFaceList, chooseImgBtn);
//            }
//            //���û�����ֵ
//            videoIRImageEngine.ASFSetLivenessParam(thresholdRgb, thresholdIr);

//            initVideo();
//        }
//        catch (Exception ex)
//        {
//            LogUtil.LogInfo(GetType(), ex);
//            Debug.LogError("�����ʼ���쳣,����App.config���޸���־����,������־����ԭ��!");
//            //MessageBox.Show("�����ʼ���쳣,����App.config���޸���־����,������־����ԭ��!");

//            Quit();
//            //System.Environment.Exit(0);
//        }
//    }




//}
