using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

[RequireComponent(typeof(Camera))]
public class PhotoCamera : MonoBehaviour
{
    public static List<Sprite> Photos { get; private set; } = new();
    public static List<QuestPhotoObject> QuestPhotoObjects { get; private set;} = new();

    private int photoWidth = 1024;
    private int photoHeight = 512;

    private string saveAsImageExternalPath = "/Images/";
    
    private Camera cam;
    [SerializeField] private Camera selfieCamera;

    private RenderTexture photoRenderTexture;
    private RenderTexture selfieRenderTexture;

    private AudioSource audioSource;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        //selfieCamera = gameObject.GetComponentInChildren<Camera>();
        audioSource = GetComponent<AudioSource>();

        photoRenderTexture = cam.targetTexture;
        photoRenderTexture.width = photoWidth;
        photoRenderTexture.height = photoHeight;

        selfieRenderTexture = new RenderTexture(photoWidth, photoHeight, photoRenderTexture.depth);
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

    public QuestPhotoObject IsTargetObjectsCaptured()
    {
        //Debug.Log(audioSource);
        audioSource.Play();

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
                    QuestPhotoObject questPhotoObject = hitInfo.transform.GetComponent<QuestPhotoObject>();
                    if (questPhotoObject)
                        return questPhotoObject;
                }
            }
        }

        return null;
    }

    public void AddPhoto(QuestPhotoObject questPhotoObject)
    {
        if (!QuestPhotoObjects.Contains(questPhotoObject))
        {
            QuestPhotoObjects.Add(questPhotoObject);
            Photos.Add(CaptureScreenAsSprite());
        }
    }

    public Sprite CaptureScreenAsSprite()
    {
        RenderTexture renderTexture;

        if (selfieCamera.gameObject.activeInHierarchy)
        {
            renderTexture = selfieRenderTexture;
            selfieCamera.targetTexture = selfieRenderTexture;
            selfieCamera.Render();
            selfieCamera.targetTexture = null;
        }
        else
        {
            renderTexture = photoRenderTexture;
            cam.targetTexture = photoRenderTexture;
        }

        Rect rect = new Rect(0, 0, photoWidth, photoHeight);
        Texture2D texture = ToTexture2D(renderTexture);

        Sprite sprite = Sprite.Create(texture, rect, Vector2.zero);

        return sprite;
    }

    public void SaveAsImage()
    {
        Texture2D texture = ToTexture2D(photoRenderTexture);
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