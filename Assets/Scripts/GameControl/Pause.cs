using UnityEngine;

// Quits the player when the user hits escape

public class ExampleClass : MonoBehaviour
{
    private FirstPersonMovement _playerMovement;
    private FirstPersonLook _playerCamera;
    public GameObject PauseCanvas;
    private void Awake()
    {
        _playerMovement = FindObjectOfType<FirstPersonMovement>();
        _playerCamera = FindObjectOfType<FirstPersonLook>();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        _playerMovement.SetMovement(false);
        _playerCamera.SetCameraRotation(false);
        PauseCanvas.SetActive(true);
    }
    public void CloseMenu()
    {
        _playerMovement.SetMovement(true);
        _playerCamera.SetCameraRotation(true);
        PauseCanvas.SetActive(false);
    }

}