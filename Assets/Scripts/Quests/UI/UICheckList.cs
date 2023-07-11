using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIMainTasks;
    [SerializeField] private TextMeshProUGUI UISecondaryTasks;
    [SerializeField] private TextMeshProUGUI[] Tasks;
    private static UICheckList __instance;
    public static UICheckList GetInstance { get { return __instance; } }
    private void Awake()
    {
        if (!__instance) { __instance = this; } else { Destroy(gameObject); }

        UIMainTasks.text = string.Empty;
        UISecondaryTasks.text = string.Empty;

        for (int i = 0; i < Tasks.Length; i++)
        {
            if (i < QuestStorage.GetMainQuestsLength)
            {
                UIMainTasks.text += Tasks[i].text + "\n";
            }
        }
    }
    public void AddQuestInformation(Quest quest, string QuestInfo)
    {
        int ind = QuestStorage.GetInstance.GetIndexByQuest(quest);
        if (ind > 5)
        {
            UISecondaryTasks.text += QuestInfo + "\n";
        }
    }
    public void CompleteTask(Quest quest)
    {
        if (quest.QuestStatus == QuestStatuses.Completed || quest.QuestStatus == QuestStatuses.broken)
            return;

        int ind = QuestStorage.GetInstance.GetIndexByQuest(quest);

        if (ind < 0)
        {
            Debug.Log("index out of range");
            return;
        }
        //Debug.Log("Quest index: " + index );   
        if (ind > 5)
        {
            UISecondaryTasks.text += "(выполнено)\n";
            return;
        }

        Tasks[ind].text += "(выполнено)";
        UIMainTasks.text = "";
        for (int i = 0; i < Tasks.Length; i++)
        {
            UIMainTasks.text += Tasks[i].text + "\n";
        }
    }
}