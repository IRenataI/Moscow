using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public static void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
