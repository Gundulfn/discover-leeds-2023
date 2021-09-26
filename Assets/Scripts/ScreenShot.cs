using UnityEngine;
using System;
using System.IO;
using TMPro;

public class ScreenShot: MonoBehaviour
{
    public TextMeshProUGUI text;
    private Camera cam;
    private string screenShotPath;

    void Start()
    {
        cam = GetComponent<Camera>();

        screenShotPath = Application.dataPath + "/ScreenShoots";
    }
    
    public void TakeScreenShot()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        
        cam.targetTexture = rt;
        cam.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        
        cam.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        
        Destroy(rt);
        

        if(!Directory.Exists(screenShotPath))
        {
            Directory.CreateDirectory(screenShotPath);
        }

        byte[] bytes = screenShot.EncodeToPNG();
        string fileName = screenShotPath + "/art-" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        File.WriteAllBytes(fileName, bytes);
    }
}