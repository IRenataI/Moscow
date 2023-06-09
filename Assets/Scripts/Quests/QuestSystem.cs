using System.Linq;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField]private Quest[] CurrentQuests;
    private UICheckList __checkList;
    private FinishGame __finishGame;
    const int MAINQUESTLENGTH = 5;
    private bool[] __mainQuests = new bool[MAINQUESTLENGTH];
    public int UpdateMainQuest { set 
        { 
            if (value > -1 && value < MAINQUESTLENGTH)
            {
                __mainQuests[value] = true;
                __finishGame.CheckFinishCondition();
                Debug.Log("main quest updated: " + value);
            }
        } 
    }
    public bool[] GetMainQuests { get { return __mainQuests; } }
    private void Awake()
    {
        __checkList = FindObjectOfType<UICheckList>();
        __finishGame = FindObjectOfType<FinishGame>();
    }
    public void UpdateTaskUI(Quest quest)
    {
        for (int i = 0; i < CurrentQuests.Length; i++)
        {
            if (quest == CurrentQuests[i])
            {
                if(quest.QuestIndex > -1) { __checkList.UpdateTasks(quest.QuestIndex); }
                __checkList.UpdateTasks(i);
                __finishGame.CheckFinishCondition();
                Debug.Log("checklist updated");
            }else if(quest.QuestIndex == CurrentQuests[i].QuestIndex && CurrentQuests[i].QuestIndex > 0)
            {
                CurrentQuests[i].QuestStatus = Quest.QuestStatuses.broken;
            }
        }
    }
    public int GetIndexByQuest(Quest quest)
    {
        for (int i = 0; i < CurrentQuests.Length; i++)
        {
            if (CurrentQuests[i] == quest)
            {
                return i;
            }
        }
        return -1;
    }
    public Quest GetQuestByIndex(int index)
    {
        return CurrentQuests[index];
    }
    public Quest GetCurrentQuest(Quest quest)
    {
        return CurrentQuests.SingleOrDefault(i => i == quest);
    }
}
/*
private void FixedUpdate()
{
    if (__quest != null && GameInputManager.IsSpacePressed())
    {
        __quest.Invoke();
        //Debug.Log("Quest is running");
    }
    if (GameInputManager.IsTabPressed())
    {
        CurrentQuests[index].EndQuest();
        //Debug.Log("Quest is done");
    }
}
*/

/*
    public void StartQuest(Quest quest)
    {
        for (int i = 0; i < CurrentQuests.Length; i++)
        {
            if (CurrentQuests[i] == quest && quest.QuestStatus != Quest.QuestStatuses.Completed)// !quest.IsQuestCompleted)
            {
                index = i;
                break;
            }
            else
            {
                index = -1;
            }
        }
        __isQuestEnable = true;
        Debug.Log("Quest index: " + index);
    }
    public void EndQuest()
    {
        Debug.Log("Completed quest's index: " + index);
        __checkList.UpdateTasks(index);
        __isQuestEnable = false;
        __finishGame.CheckFinishCondition();
    }
    */