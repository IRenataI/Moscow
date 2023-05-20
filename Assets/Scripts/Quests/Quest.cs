using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Quest : MonoBehaviour, QuestInterface
{
    public bool IsQuestCompleted = false;
    private QuestSystem __questSystem;
    private PlayerMovement __player;
    private bool __isQuestRunning = false;
    private UICheckList __checkList;
    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<PlayerMovement>();
        __checkList = FindAnyObjectByType<UICheckList>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            __questSystem.StartQuest(this);
        }
        //Debug.Log("Started quest: " + other.name);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            __questSystem.EndQuest(this);
        }
        //Debug.Log("Ended quest: " + other.name);
    }
    public void StartQuest()
    {
        __questSystem.StartQuest(this);
        __isQuestRunning = true;
    }
    public void EndQuest()
    {
        __isQuestRunning = false;
        __questSystem.EndQuest(this);
        IsQuestCompleted = true;

        __checkList.UpdateTasks(0);
    }
    private void FixedUpdate()
    {
        if (IsQuestCompleted)
        {
            return;
        }
        if (__isQuestRunning)
        {
            __player.transform.position = Vector3.Lerp(__player.transform.position,
            transform.position, 0.05f);
            //Debug.Log("Quest is running");
        }
        if (GameInputManager.IsTabPressed())
        {
            EndQuest();
            Debug.Log("Quest is done");
        }
    }
}
