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
    public static int GetMainQuestsLength => MAINQUESTLENGTH;

    private void Awake()
    {
        __checkList = FindObjectOfType<UICheckList>();
        __finishGame = FindObjectOfType<FinishGame>();
    }
    public void UpdateTaskUI(Quest quest)
    {
        for (int i = 0; i < CurrentQuests.Length; i++)
        {
            if (quest == CurrentQuests[i] && quest.QuestStatus != Quest.QuestStatuses.Completed)
            {
                if(quest.QuestIndex > -1) 
                { 
                    __checkList.CompleteTask(quest.QuestIndex);
                    quest.IsCheckListUpdated = true;
                }              
                if (!quest.IsCheckListUpdated)
                {
                    __checkList.CompleteTask(i);
                    quest.IsCheckListUpdated = true;
                }
                __finishGame.CheckFinishCondition();
                Debug.Log("checklist updated: " + CurrentQuests[i].gameObject.name);
            }
            if (CurrentQuests[i].QuestIndex < 0)
            {
                //Debug.Log(CurrentQuests[i].QuestIndex);
                continue;
            }
            if (quest != CurrentQuests[i] && quest.QuestIndex == CurrentQuests[i].QuestIndex)
            {
                CurrentQuests[i].QuestStatus = Quest.QuestStatuses.broken;
                //Debug.Log("quest broken: " + CurrentQuests[i].gameObject.name);
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
}