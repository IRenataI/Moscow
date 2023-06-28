using UnityEngine;

public class ButtonToPressUI : MonoBehaviour
{
    private static Canvas __canvas;
    void Awake()
    {
        __canvas = GetComponent<Canvas>();
        __canvas.enabled = false;
    }
    public static void EnableCanvas()
    {
        __canvas.enabled = true;
    }
    public static void DisableCanvas()
    {
        __canvas.enabled = false;
    }
}
