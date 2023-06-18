using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TargetsManager : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    private Texture2D MusicTexture;
    [SerializeField] private RawImage MusicImage;
    [SerializeField] private RectTransform MusicImageTransform;
    [SerializeField] private TextMeshProUGUI Accuracy;
    public TargetsAbstract[] Targets = new TargetsAbstract[4];
    public float __delayBetweenSpawns = 1f;
    public Transform GuitarCanvas;
    private Vector3[] TargetPosition = new Vector3[4];
    private bool __isSpawning = false;
    private float __timer = 0;
    private WinCondition __winCondition;
    private LinkedList<GameObject> __spawnedObjects = new LinkedList<GameObject>();

    private float __songPosition = 0;
    private int scale = 10;

    private float __tempAccuracy = 0f; 
    private float __accuracy = 0f; 
    private void Awake()
    {
        for (int i = 0; i < TargetPosition.Length; i++)
        {
            TargetPosition[i] = Targets[i].transform.localPosition;           
        }
        __winCondition = GetComponent<WinCondition>();        
    }
    public void StartTargetsSpawn()
    {
        Music.Play();
        PaintTexture();
        __isSpawning = true;
    }
    public void StopTargetsSpawn()
    {
        __spawnedObjects.Last().GetComponent<GuitarTarget>().ResetVelocity();

        __isSpawning = false;
        while (__spawnedObjects.Count > 0) 
        {
            GameObject __temp = __spawnedObjects.Last();
            __spawnedObjects.Remove(__temp);
            Destroy(__temp);
        }
        __spawnedObjects.Clear();
    }

    private int k = 1; // default 5
    private void FixedUpdate()
    {
        if (!__isSpawning)
        {
            __songPosition = 0;
            return;
        }
        __songPosition = Music.time * Music.clip.channels * scale / k ; //(int)(Music.clip.length * Music.clip.channels * scale / k) * Time.fixedDeltaTime;//(Music.clip.length / k / MusicImageTransform.sizeDelta.x) * Time.fixedDeltaTime;
        //Debug.Log(Music.time);


        foreach (var obj in __spawnedObjects)
        {
            __tempAccuracy += obj.GetComponent<GuitarTarget>().GetAccuracy;
        }
        __accuracy = (int)( 100 * __tempAccuracy / __spawnedObjects.Count);
        __tempAccuracy = 0;
        if (__spawnedObjects.Count > 0)
            Accuracy.text = "Точность: " + __accuracy + "%";

        UpdateTexture();

        if (MusicTexture.GetPixel((int)__songPosition, 115) != new Color(0,0,0,0) &&
            __timer > __delayBetweenSpawns)
        {
            int __randomNumber = Random.Range(0, 4);
            TargetsAbstract __temp = Instantiate(Targets[__randomNumber]);

            __temp.transform.SetParent(GuitarCanvas);
            __temp.transform.localPosition = TargetPosition[__randomNumber];
            __temp.transform.localScale = new Vector3(1, 1, 1);

            __temp.SetWinCodition(__winCondition);

            __timer = 0;

            __spawnedObjects.AddLast(__temp.gameObject);
        }
        else
        {
            Debug.Log(MusicTexture.GetPixel((int)__songPosition, 150));
        }
        __timer = Mathf.Clamp(__timer + Time.fixedDeltaTime, 0, __delayBetweenSpawns + 1);
    }

    int c_hi = 0;
    int c_low = 0;
    float s_hi = 0;
    float s_low = 0;
    private void PaintTexture()
    {
        float[] samples = new float[Music.clip.samples * Music.clip.channels];
        Music.clip.GetData(samples, 0); //Получаем массив с данными сэмпла по которому будет строиться текстура
        int frequency = Music.clip.frequency; //битрейт сэмпла
        scale = 10; //пикселей на 1с сэмпла // default 10

        int width = (int)(Music.clip.length * Music.clip.channels * scale / k);

        MusicTexture = new Texture2D(width, 200);

        MusicImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        MusicImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
        //
        MusicTexture.name = "GuitarHeroTexture";
        MusicImage.texture = MusicTexture;
        MusicImage.transform.localScale = new Vector2(0.5f, 0.5f);
        //

        int height = (int)(MusicTexture.height / 2);
        for (int i = 0; i < MusicTexture.width; i++)
        {
            c_hi = 0;
            c_low = 0;
            s_hi = 0;
            s_low = 0;

            //Подсчитываем среднее нижнее и среднее верхнее значение на 1px текстуры
            for (int k = 0; k < (int)(frequency / scale); k++)
            {
                if (samples[k + i * (int)(frequency / scale)] >= 0)
                {
                    c_hi++;
                    s_hi += samples[k + i * (int)(frequency / scale)];
                }
                else
                {
                    c_low++;
                    s_low += samples[k + i * (int)(frequency / scale)];
                }
            }

            //Рисуем линию от среднего нижнего до среднего верхнего 
            //Поделена она на более светлую внутреннюю и более темную верхнюю часть, исключительно для красоты
            for (int j = 0; j < (int)(MusicTexture.height); j++)
            {
                if (j < (int)((s_hi / c_hi) * height * 0.6f + height) &&
                    j > (int)((s_low / c_low) * height * 0.6f + height))
                    MusicTexture.SetPixel(i, j, new Color(0.7f, 1, 0.7f));
                else
                if (j <= (int)((s_hi / c_hi) * height + height) &&
                    j >= (int)((s_low / c_low) * height + height))
                    MusicTexture.SetPixel(i, j, new Color(0, 1, 0));
                else MusicTexture.SetPixel(i, j, new Color(0, 0, 0, 0));
            }
        }
        MusicTexture.Apply();
        //Debug.Log("texture apply " + "height: " + Texture.height + " width: " + Texture.width);
    }
    private void UpdateTexture()
    {
        for (int i = (int)(__songPosition - 1); i < Mathf.Clamp(__songPosition,0, MusicTexture.width); i++)
        {
            for (int j = 1; j < 50; j++)
            {
                MusicTexture.SetPixel(i, j, Color.green);
            }
        }
        MusicTexture.Apply();
    }
}
