using UnityEngine;
using UnityEngine.UI;

public class Comix : MonoBehaviour
{
    [SerializeField] private RawImage[] Pages;
    private RawImage[] __materials;
    public float AppearTime = 0.04f, DelayBetweenPages = 1f;
    private float __delay = 0f, __delay2 = 0;
    private void Awake()
    {
        __materials = new RawImage[Pages.Length];
        for (int i = 0; i < Pages.Length; i++)
        {
            __materials[i] = Pages[i].GetComponent<RawImage>();

            __materials[i].color = new Color(__materials[i].color.r, 
                __materials[i].color.g, __materials[i].color.b, 0f);
        }
    }
    int i = 0;
    private void FixedUpdate()
    {
        if (__delay > AppearTime)
        {
            __materials[i].color += new Color(0, 0, 0, 0.02f);
            __delay = 0;
            if (__materials[i].color.a > 0.99f)
            {                
                __delay2 += Time.fixedDeltaTime;
                if (__delay2 > DelayBetweenPages)
                {
                    i = Mathf.Clamp(i + 1, 0, Pages.Length - 1);
                    __delay2 = 0;
                }
            }
        }
        __delay += Time.fixedDeltaTime;
        if (i >= Pages.Length - 1 && Input.GetMouseButtonDown(0))
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
