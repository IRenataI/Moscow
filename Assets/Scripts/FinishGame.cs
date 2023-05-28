using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public Canvas EndCanvas;
    private FirstPersonMovement __movement;
    private FirstPersonLook __camera;
    private QuestSystem __questSystem;
    private void Awake()
    {
        __movement = FindObjectOfType<FirstPersonMovement>();
        __camera = FindObjectOfType<FirstPersonLook>();
        __questSystem = FindObjectOfType<QuestSystem>();
    }
    private void FixedUpdate()
    {
        EndGame();
    }
    private void EndGame()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!__questSystem.GetQuestByIndex(i).IsQuestCompleted)
            {
                return;
            }
        }
        __movement.SetMovement(false);
        __camera.SetCameraRotation(false);
        Cursor.lockState = CursorLockMode.Confined;
        EndCanvas.gameObject.SetActive(true);
    }
}
