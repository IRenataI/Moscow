using TMPro;
using UnityEngine;

public class UICheckList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] Tasks;
    private void Awake()
    {
        for (int i = 0; i < Tasks.Length; i++) 
        {
            Tasks[i].text = "Задача " + (i + 1);
        }
    }
    public void UpdateTasks(int index)
    {
        Debug.Log(index);
        if (index > -1)
            Tasks[index].text += "(завершено)";//(index + 1) + "(завершено)";
    }
}
