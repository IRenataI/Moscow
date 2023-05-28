using UnityEngine;

public class GameSystem : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 60;
    }
    public static void ChangeCursorMode(CursorLockMode mode)
    {
        Cursor.lockState = mode;
    }
    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
