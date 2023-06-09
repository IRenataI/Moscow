using UnityEngine;

public class QuestPhotoObject : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;

    public bool AllowQuest = true;
    public string Description;

    private void Start()
    {
        winCondition = GetComponent<WinCondition>();
    }

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