using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] Tasks = new TextMeshProUGUI[0];
    private QuestSystem __questSystem;
    private void Awake()
    {
		__questSystem = FindObjectOfType<QuestSystem>();       
    }
    public void UpdateTasks(int index)
    {
        Debug.Log(index);
        Tasks[index].text = "Task " + (index + 1) + " is completed";
    }
}
