using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class PhotoCamera : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    
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
        //if (Input.GetKeyDown(GlobalVariables.TakePhotoKey))
        //{
        //    IsTargetObjectCaptured(targetObject);
        //}
    }

    public bool IsTargetObjectCaptured(GameObject targetObject)
    {
        if (targetObject == null)
            return false;

        float stepCount = 30f;

        float xStep = Screen.width / stepCount;
        float yStep = Screen.height / stepCount;

        //Debug.Log($"{Screen.width}x{Screen.height} : {xStep}, {yStep}");

        Ray ray;

        for (float x = 0; x <= Screen.width; x += xStep)
        {
            for (float y = 0; y <= Screen.height; y += yStep)
            {
                ray = cam.ScreenPointToRay(new Vector3(x, y, 0f));
                
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    if (hitInfo.transform.gameObject == targetObject)
                    {
                        return true;
                        //Debug.Log($"YAY! Screen point: ({x}, {y})");
                    }
                }
            }
        }

        return false;
    }

    public QuestPhotoObject IsTargetObjectsCaptured(List<QuestPhotoObject> targetObjects)
    {
        if (targetObjects == null || targetObjects.Count <= 0)
            return null;

        float stepCount = 30f;

        float xStep = Screen.width / stepCount;
        float yStep = Screen.height / stepCount;

        Ray ray;

        for (float x = 0; x <= Screen.width; x += xStep)
        {
            for (float y = 0; y <= Screen.height; y += yStep)
            {
                ray = cam.ScreenPointToRay(new Vector3(x, y, 0f));

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    foreach (QuestPhotoObject questObject in targetObjects)
                    {
                        if (hitInfo.transform.gameObject == questObject.gameObject)
                        {
                            return questObject;
                        }
                    }
                }
            }
        }

        return null;
    }

    public void SaveAsImage()
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