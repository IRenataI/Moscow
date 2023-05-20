using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private Quest[] __quests = new Quest[0];
    public delegate void Quests();
    Quests __quest;
    public void StartQuest(Quest quest)
    {
        if (!quest.IsQuestCompleted)
            __quest = quest.StartQuest;
    }
    public void EndQuest(Quest quest)
    {
        __quest -= quest.StartQuest;
    }
    private void FixedUpdate()
    {
        if (__quest != null && GameInputManager.IsSpacePressed())
        {
            __quest.Invoke();
            Debug.Log("Quest is running");
        }
    }
}
