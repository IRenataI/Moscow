using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Quest : MonoBehaviour
{
    public WinCondition WinCondition;
    public bool IsQuestCompleted = false;
    public UnityEvent EventOnStart;
    public UnityEvent EventOnEnd;
    private QuestSystem __questSystem;
    private PlayerMovement __player;
    private bool __isQuestRunning = false;
    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<PlayerMovement>();
    }
    public void StartQuest()
    {
        __player.transform.position = Vector3.Lerp(__player.transform.position, transform.position, 0.05f);
    
        __isQuestRunning = true;
        __questSystem.StartQuest(this);
        EventOnStart?.Invoke();
    }
    public void EndQuest()
    {
        __isQuestRunning = false;
        __questSystem.EndQuest();
        IsQuestCompleted = true;
        EventOnEnd?.Invoke();

        Debug.Log("Quest completed");
    }
    private void FixedUpdate()
    {
        if (IsQuestCompleted)
            return;

        if (__isQuestRunning)
        {
            //__player.transform.position = Vector3.Lerp(__player.transform.position,transform.position, 0.05f);
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
/*
private void OnTriggerStay(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        StartQuest();
    }
    //Debug.Log("Started quest: " + other.name);
}
*/