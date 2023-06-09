using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WinCondition))]
[RequireComponent(typeof(QuestInteractable))]
public class Quest : MonoBehaviour
{
    public int QuestIndex = -5;
    public int PlusSubscribers = 50;
    public Transform QuestStartPosition;
    public UnityEvent EventOnStart;
    public UnityEvent EventOnInterrupt;
    public UnityEvent EventOnEnd;
    public bool IsCheckListUpdated = false;
    private QuestSystem __questSystem;
    private FirstPersonMovement __player;
    private FirstPersonLook __cameraRotation;
    private WinCondition __winConditon;
    private QuestStatuses __questStatus;    
    public QuestStatuses QuestStatus { set { __questStatus = value; } get { return __questStatus; } }
    public enum QuestStatuses
    {
        Started, Completed, None,  broken
    }
    void Awake()
    {
        QuestStatus = QuestStatuses.None;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<FirstPersonMovement>();
        __cameraRotation = FindAnyObjectByType<FirstPersonLook>();
        __winConditon = GetComponent<WinCondition>();
    }
    public void StartQuest(int price)
    {
        if (!Money.WasteMoney(price))
            return;

        EventOnStart?.Invoke();
        __player.SetMovement(false);

        __questStatus = QuestStatuses.Started;

        Debug.Log("Quest started: " + gameObject.name);
    }
    public void EndQuest()
    {
        if (__questStatus == QuestStatuses.broken)
            return;
        EventOnEnd?.Invoke();
        __player.SetMovement(true);
        __cameraRotation.SetCameraRotation(true);
        Subscribers.EarnSubscribers(PlusSubscribers);
        __questSystem.UpdateTaskUI(this);
        __questStatus = QuestStatuses.Completed;

        __questSystem.UpdateMainQuest = QuestIndex;

        QuestCompletionSound.Play();

        Debug.Log("Quest completed: " + gameObject.name);
    }
    public void InterruptQuest()
    {
        EventOnInterrupt?.Invoke();

        __player.SetMovement(true);
        __cameraRotation.SetCameraRotation(true);
        __winConditon.ResetHittedTargets();

        __questStatus = QuestStatuses.None;

        Debug.Log("Quest interrupted");
    }
    private bool __isInPosition = false;
    private void FixedUpdate()
    {
        if (__questStatus != QuestStatuses.Started || !QuestStartPosition)
            return;

        if ((QuestStartPosition.transform.position - __player.transform.position).magnitude > 0.1f)
        {
            if (!__isInPosition)
            {
                __player.transform.position = Vector3.Lerp(__player.transform.position, QuestStartPosition.transform.position, 0.1f);
            }
        }
        if ((QuestStartPosition.transform.position - __player.transform.position).magnitude < 0.4f)
        {
            __isInPosition = true;
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

//public bool IsQuestCompleted = false;
//private bool __isQuestStarted = false;

/*
if (IsQuestCompleted)
{
    __player.SetMovement(true);
    __cameraRotation.SetCameraRotation(true);
    Debug.Log("Quest already done");
    return;
}
*/

/*else if ((QuestStartPosition.transform.position - __player.transform.position).magnitude < 1f)
{
    __isQuestStarted = false;
}
*/

//GetComponent<BoxCollider>().isTrigger = true;