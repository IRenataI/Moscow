using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private FirstPersonLook __camera;
    private FirstPersonMovement __player;
    private void Awake()
    {
        __camera = FindObjectOfType<FirstPersonLook>(); //.SetCameraRotation(false);
        __player = FindObjectOfType<FirstPersonMovement>();
        __player.SetMovement(false);
        __camera.canRotate = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
