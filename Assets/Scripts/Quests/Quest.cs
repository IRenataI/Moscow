using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Quest : MonoBehaviour
{
    public bool IsQuestCompleted = false;
    private QuestSystem __questSystem;
    private PlayerMovement __player;
    private bool __isQuestRunning = false;
    //private UICheckList __checkList;
    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<PlayerMovement>();
        //__checkList = FindAnyObjectByType<UICheckList>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartQuest();
        }
        //Debug.Log("Started quest: " + other.name);
    }
    private void StartQuest()
    {
        __questSystem.StartQuest(this);
        __isQuestRunning = true;
    }
    private void EndQuest()
    {
        __isQuestRunning = false;
        __questSystem.EndQuest(this);
        IsQuestCompleted = true;

        //__checkList.UpdateTasks(0);
        Debug.Log("Quest completed");
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
    }
}
/*
private void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        EndQuest();
    }
    //Debug.Log("Ended quest: " + other.name);
}
*/