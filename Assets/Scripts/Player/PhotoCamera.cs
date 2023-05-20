using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PhotoCamera : MonoBehaviour
{
    private string saveAsImageExternalPath = "/Images/";
    
    private Camera cam;
    private RenderTexture renderTexture;

    private void Start()
    {
        cam = GetComponent<Camera>();
        renderTexture = cam.targetTexture;
    }

    private void Update()
    {
        if (Input.GetKeyDown(GlobalVariables.TakePhotoKey))
            SaveAsImage();
    }

    private void SaveAsImage()
    {
        Texture2D texture = ToTexture2D(renderTexture);
        byte[] textureInBytes = texture.EncodeToPNG();
        string dirPath = Application.dataPath + saveAsImageExternalPath;
        
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
        
        File.WriteAllBytes($"{dirPath}IMG_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.png", textureInBytes);
    }

    private Texture2D ToTexture2D(RenderTexture renderTexture)
    {
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();
        
        return texture2D;
    }
}