using UnityEngine;

public class QuestPhotoObject : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;

    public bool AllowQuest = true;

    public void IncreaceProgress()
    {
        Debug.Log("IncreaceProgress");
        winCondition.IncreaseHittedTargets();
    }

    public void Allow()
    {
        AllowQuest = true;
    }
}