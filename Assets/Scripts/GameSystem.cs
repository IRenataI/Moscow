using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private FirstPersonLook __camera;
    private FirstPersonMovement __player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Application.targetFrameRate = 60;
        __camera = FindObjectOfType<FirstPersonLook>(); //.SetCameraRotation(false);
        __player = FindObjectOfType<FirstPersonMovement>();
        __player.SetMovement(false);
        __camera.canRotate = false;
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
