using UnityEngine;
using UnityEngine.UI;

public class BlackScreenUI : MonoBehaviour
{
    private static Color __BlackScreenColor;
    private static Image __image;
    private static bool __isBlackScreenEnabled = false;
    private float __transparentCapacity = 0;
    private Color __basicColor = new Color(0, 0, 0, 0);
    private float __speed = 0.01f;
    private void Awake()
    {
        __image = GetComponent<Image>();
        Material newBlackMaterial = new Material(Shader.Find("UI/Lit/Transparent"));
        newBlackMaterial.color = Color.black;
        __image.material = newBlackMaterial;
        __BlackScreenColor = __basicColor;
    }
    public static void EnableBlackScreen()
    {
        __isBlackScreenEnabled = true;
        __image.enabled = true;
    }
    public static void DisableBlackScreen()
    {
        __isBlackScreenEnabled = false;
    }
    public static float GetBlackScreenAlpha()
    {
        return __BlackScreenColor.a;
    }
    public static bool IsScreenDisable()
    {
        return __image.IsActive();
    }
    private void FixedUpdate()
    {
        if (!__image.enabled)
            return;
        if (!__isBlackScreenEnabled)
        {
            if (__BlackScreenColor.a > 0.01f)
            {
                __BlackScreenColor = new Color(0, 0, 0, __transparentCapacity);
                __image.material.color = __BlackScreenColor;
                __transparentCapacity -= __speed;
                Debug.Log(__BlackScreenColor);
            }
            else
            {
                __image.enabled = false;
            }
            return;
        }

        __BlackScreenColor = new Color(0,0,0, __transparentCapacity);
        __image.material.color = __BlackScreenColor;
        __transparentCapacity += __speed;
        Debug.Log(__BlackScreenColor);
    }
}
