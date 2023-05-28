using UnityEngine;

public class QuestPhotoObject : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;

    public void IncreaceProgress()
    {
        winCondition.IncreaseHittedTargets();
    }
}