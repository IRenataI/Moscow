using System;
using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] Tasks = new TextMeshProUGUI[0];
    private QuestSystem __questSystem;
    private void Awake()
    {
		try{__questSystem = FindObjectOfType<QuestSystem>();
        }catch (NullReferenceException error){throw error;}
    }
    public void UpdateTasks(int index)
    {
        Tasks[index].text = "Task " + (index + 1) + " is completed";
    }
}
