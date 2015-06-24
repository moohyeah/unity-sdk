using System.IO;
using UnityEngine;
using UnityEditor;
using Qiniu.RS;
using Qiniu.Conf;
using Qiniu.IO.Resumable;

public class TestWizard : EditorWindow {

    private static readonly string qiniuBucket = "test";

    static TestWizard()
    {
        // 从服务器获取应该是比较安全的做法 
        Qiniu.Conf.Config.ACCESS_KEY = "your ACCESS_KEY";
        Qiniu.Conf.Config.SECRET_KEY = "your SECRET_KEY";
    }

    [MenuItem("Test/Upload")]
    public static void TestUpload() {
        
        string path = EditorUtility.OpenFilePanel("Select File", "", "*");
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        PutPolicy policy = new PutPolicy(qiniuBucket, 3600);
        string upToken = policy.Token();
        string key = SystemInfo.deviceUniqueIdentifier + "_" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + Path.GetFileName(path);
        Settings setting = new Settings();
        ResumablePutExtra extra = new ResumablePutExtra();
        ResumablePut client = new ResumablePut(setting, extra);
        client.PutFile(upToken, path, key);
    }

}
