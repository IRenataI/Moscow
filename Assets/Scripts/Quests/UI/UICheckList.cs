using System;
using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UITasks;
    [SerializeField] private TextMeshProUGUI[] Tasks;
    private QuestSystem __questSystem;
    private void Awake()
    {
        __questSystem = FindObjectOfType<QuestSystem>();
        UITasks.text = string.Empty;
        for (int i = 0; i < Tasks.Length; i++)
        {
            Tasks[i].text = "Задача " + (i + 1);
            UITasks.text += Tasks[i].text + "\n";
        }
    }
    public void UpdateTasks(int index)
    {
        Debug.Log(index);
        if (index > -1 && !__questSystem.GetCurrentQuest.IsQuestCompleted)
        {
            Tasks[index].text += "(выполнено)";//(index + 1) + "(çàâåðøåíî)";
            UpdateUITasks();
        }
        else
            Debug.Log("index < 0");
    }

    private void UpdateUITasks()
    {
        UITasks.text = string.Empty;

        for (int i = 0; i < Tasks.Length; i++)
        {
            UITasks.text += Tasks[i].text + "\n";
        }
    }
}
