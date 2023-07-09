using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public Canvas EndCanvas;
    private FirstPersonMovement __movement;
    private FirstPersonLook __camera;
    private static FinishGame __instance;
    public static FinishGame GetInstance => __instance;
    private void Awake()
    {
        if (!__instance)
        {
            __instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        __movement = FindObjectOfType<FirstPersonMovement>();
        __camera = FindObjectOfType<FirstPersonLook>();
    }
    public void CheckFinishCondition()
    {
        bool[] mainQuests = QuestStorage.GetInstance.GetMainQuests;
        for (int i = 0; i < mainQuests.Length; i++)
        {
            if (!mainQuests[i])
            {
                return;
            }
        }
        Debug.Log("game finished");
        __movement.SetMovement(false);
        __camera.SetCameraRotation(false);
        Cursor.lockState = CursorLockMode.Confined;
        EndCanvas.gameObject.SetActive(true);
    }
}