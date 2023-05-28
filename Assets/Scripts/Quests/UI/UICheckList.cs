using System;
using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] Tasks;
    private QuestSystem __questSystem;
    private void Awake()
    {
        __questSystem = FindObjectOfType<QuestSystem>();
        for (int i = 0; i < Tasks.Length; i++) 
        {
            Tasks[i].text = "������ " + (i + 1);
        }
    }
    public void UpdateTasks(int index)
    {
        Debug.Log(index);
        if (index > -1 && !__questSystem.GetCurrentQuest.IsQuestCompleted)
            Tasks[index].text += "(���������)";//(index + 1) + "(���������)";
        else
            throw new NullReferenceException("index < 0");
    }
}
