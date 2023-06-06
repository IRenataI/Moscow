using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField]private Quest[] __currentQuests;
    private delegate void DelegateQuests();
    private UICheckList __checkList;
    private int index = -1;
    private bool __isQuestEnable = false;
    public bool IsQuestEnable { get { return __isQuestEnable; } }
    public Quest GetCurrentQuest { get { return __currentQuests[index]; } }
    public int GetCurrentQuestIndex { get { return index; } }
    private FinishGame __finishGame;
    private void Awake()
    {
        __checkList = FindObjectOfType<UICheckList>();
        __finishGame = FindObjectOfType<FinishGame>();
    }
    public void StartQuest(Quest quest)
    {
        for (int i = 0; i < __currentQuests.Length; i++)
        {
            if (__currentQuests[i] == quest && quest.QuestStatus != Quest.QuestStatuses.Completed)// !quest.IsQuestCompleted)
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
    public int GetIndexByQuest(Quest quest)
    {
        for (int i = 0; i < __currentQuests.Length; i++)
        {
            if (__currentQuests[i] == quest)
            {
                return i;
            }
        }
        return -1;
    }
    public Quest GetQuestByIndex(int index)
    {
        return __currentQuests[index];
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
        __currentQuests[index].EndQuest();
        //Debug.Log("Quest is done");
    }
}
*/