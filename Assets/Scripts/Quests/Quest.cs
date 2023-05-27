using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(WinCondition))]
[RequireComponent(typeof(QuestInteractable))]
public class Quest : MonoBehaviour
{
    public Transform QuestStartPosition;
    public bool IsQuestCompleted = false;
    public UnityEvent EventOnStart;
    public UnityEvent EventOnInterrupt;
    public UnityEvent EventOnEnd;
    private QuestSystem __questSystem;
    private PlayerMovement __player;
    private CameraRotation __cameraRotation;
    private WinCondition __winConditon;
    private BoxCollider __boxCollider;
    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<PlayerMovement>();
        __cameraRotation = FindAnyObjectByType<CameraRotation>();
        __winConditon = GetComponent<WinCondition>();
        __boxCollider = GetComponent<BoxCollider>();
    }
    public void StartQuest()
    {
        if (IsQuestCompleted)
            return;

        __questSystem.StartQuest(this);
        EventOnStart?.Invoke();

        __player.StopMovement();
        __boxCollider.enabled = false;
    }
    public void EndQuest()
    {
        __questSystem.EndQuest();
        IsQuestCompleted = true;
        EventOnEnd?.Invoke();

        __player.ContinueMovement();
        __cameraRotation.StartRotate();

        __boxCollider.enabled = true;

        Debug.Log("Quest completed");
    }
    public void InterruptQuest()
    {
        EventOnInterrupt?.Invoke();

        __player.ContinueMovement();
        __cameraRotation.StartRotate();

        __winConditon.ResetHittedTargets();

        __boxCollider.enabled = true;

        Debug.Log("Quest interrupted");
    }
    private void FixedUpdate()
    {
        if (__boxCollider.enabled == false)
        {
            __player.transform.position = Vector3.Lerp(__player.transform.position, 
                QuestStartPosition.transform.position, 0.1f);
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
/*
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
*/