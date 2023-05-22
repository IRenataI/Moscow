using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] Tasks;
    private QuestSystem __questSystem;
    private void Awake()
    {
        __questSystem = FindAnyObjectByType<QuestSystem>();
        for (int i = 0; i < Tasks.Length; i++) 
        {
            Tasks[i].text = "Task " + (i + 1);
        }
    }
    public void UpdateTasks(int index)
    {
        Debug.Log(index);
        Tasks[index].text = "Task " + (index + 1) + " is completed";
    }
}
