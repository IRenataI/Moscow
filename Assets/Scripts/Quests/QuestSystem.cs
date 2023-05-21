using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public Quest[] CurrentQuests;
    private delegate void DelegateQuests();
    private UICheckList __checkList;
    private int index = -1;
    private void Awake()
    {
        __checkList = FindObjectOfType<UICheckList>();
        CurrentQuests = FindObjectsOfType<Quest>();
    }
    public void StartQuest(Quest quest)
    {
        for (int i = 0; i < CurrentQuests.Length; i++)
        {
            if (CurrentQuests[i] == quest && !quest.IsQuestCompleted)
            {
                index = i;
            }
        }
    }
    public void EndQuest()
    {
        __checkList.UpdateTasks(index);
        Debug.Log("Completed quest's index: " + index);
    }
}
/*
private void FixedUpdate()
{
    if (__quest != null && GameInputManager.IsSpacePressed())
    {
        __quest.Invoke();
        //Debug.Log("Quest is running");
    }
    if (GameInputManager.IsTabPressed())
    {
        CurrentQuests[index].EndQuest();
        //Debug.Log("Quest is done");
    }
}
*/