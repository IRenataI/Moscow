using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIMainTasks;
    [SerializeField] private TextMeshProUGUI UISecondaryTasks;
    [SerializeField] private TextMeshProUGUI[] Tasks;
    private QuestSystem __questSystem;
    private void Awake()
    {
        __questSystem = FindObjectOfType<QuestSystem>();
        UIMainTasks.text = string.Empty;
        UISecondaryTasks.text = string.Empty;

        for (int i = 0; i < Tasks.Length; i++)
        {
            if (i < QuestSystem.GetMainQuestsLength)
            {
                UIMainTasks.text += Tasks[i].text + "\n";
            }
        }
    }
    public void AddQuestInformation(Quest quest, string QuestInfo)
    {
        int ind = __questSystem.GetIndexByQuest(quest);
        if (ind > 5)
        {
            UISecondaryTasks.text += QuestInfo + "\n";
        }
    }
    public void CompleteTask(int index)
    {
        if (index < 0)/* && __questSystem.GetQuestByIndex(index).QuestStatus != Quest.QuestStatuses.Completed*/
        {
            Debug.Log("index out of range");
            return;
        }
        //Debug.Log("Quest index: " + index );   
        if (index > 5)
        {
            UISecondaryTasks.text += "(выполнено)\n";
            return;
        }

        Tasks[index].text += "(выполнено)";
        UIMainTasks.text = "";
        for (int i = 0; i < Tasks.Length; i++)
        {
            UIMainTasks.text += Tasks[i].text + "\n";
        }
    }
}