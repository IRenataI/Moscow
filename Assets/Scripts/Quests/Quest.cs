using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WinCondition))]
[RequireComponent(typeof(QuestInteractable))]
public class Quest : MonoBehaviour
{
    [SerializeField] private string QuestInformation;
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
    private UICheckList __checkList;
    public QuestStatuses QuestStatus { set { __questStatus = value; } get { return __questStatus; } }
    public enum QuestStatuses
    {
        Started, Completed, None,  broken
    }
    private bool __isInPosition = false;
    void Awake()
    {
        QuestStatus = QuestStatuses.None;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<FirstPersonMovement>();
        __cameraRotation = FindAnyObjectByType<FirstPersonLook>();
        __checkList = FindAnyObjectByType<UICheckList>();
        __winConditon = GetComponent<WinCondition>();
    }
    public void StartQuest(int price)
    {
        if (!Money.WasteMoney(price))
            return;

        EventOnStart?.Invoke();
        __player.SetMovement(false);

        __questStatus = QuestStatuses.Started;

        __checkList.AddQuestInformation(this, QuestInformation);

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