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
        for (int i = 0; i < Tasks.Length; i++)
        {
            if (i < QuestSystem.GetMainQuestsLength)
            {
                UIMainTasks.text += Tasks[i].text + "\n";
            }
            else
            {
                Tasks[i].text = "Задача " + (i + 1 - QuestSystem.GetMainQuestsLength);
                UISecondaryTasks.text += Tasks[i].text + "\n";
            }
        }
    }
    public void UpdateTasks(int index)
    {
        //Debug.Log("Quest index: " + index );   
        if (index > -1)/* && __questSystem.GetQuestByIndex(index).QuestStatus != Quest.QuestStatuses.Completed*/
        {
            Debug.Log("completed");
            Tasks[index].text += "(выполнено)";
            UpdateUITasks();
        }
        else
            Debug.Log("index < 0");
    }

    private void UpdateUITasks()
    {
        UIMainTasks.text = string.Empty;

        for (int i = 0; i < Tasks.Length; i++)
        {
            UIMainTasks.text += Tasks[i].text + "\n";
        }
    }
}
