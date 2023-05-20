using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private Quest[] __quests = new Quest[0];
    public delegate void Quests();
    Quests __quest;
    public void StartQuest(QuestInterface questInterface)
    {
        __quest = questInterface.StartQuest;
    }
    public void EndQuest(QuestInterface questInterface)
    {
        __quest -= questInterface.StartQuest;
    }
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            __quest.Invoke();
        }
    }
}
