using UnityEngine;

public class StartQuestOnSceneLoad : MonoBehaviour
{
    [SerializeField] private Quest[] quests;

    private void Start()
    {
        foreach(Quest quest in quests)
        {
            //quest.StartQuest(0);
        }
    }
}