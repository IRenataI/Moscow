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
    public void CheckFinishCondition()
    {
        bool[] mainQuests = __questSystem.GetMainQuests;
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

/*
public void CheckFinishCondition()
{
    for (int i = 0; i < 5; i++)
    {
        if (__questSystem.GetQuestByIndex(i).QuestStatus != Quest.QuestStatuses.Completed )
        {
            return;
        }
    }
    __movement.SetMovement(false);
    __camera.SetCameraRotation(false);
    Cursor.lockState = CursorLockMode.Confined;
    EndCanvas.gameObject.SetActive(true);
}
*/
/*
for (int i = 0; i < __questSystem.quests; i++)
{
if (__questSystem.GetQuestByIndex(i).QuestStatus != Quest.QuestStatuses.Completed)
{
    return;
}
}
*/