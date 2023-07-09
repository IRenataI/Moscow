using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WinCondition))]
[RequireComponent(typeof(QuestInteractable))]
public class Quest : MonoBehaviour
{
    [SerializeField] private string QuestInformation;
    [SerializeField] private int PlusSubscribers = 50;
    [SerializeField] private int QuestPrice = 0;
    [SerializeField] private Transform QuestStartPosition;

    public UnityEvent EventOnStart;
    public UnityEvent EventOnInterrupt;
    public UnityEvent EventOnEnd;

    public QuestStatuses QuestStatus { set { __questStatus = value; } get { return __questStatus; } }

    private FirstPersonMovement __player;
    private FirstPersonLook __cameraRotation;
    private WinCondition __winConditon;
    private QuestStatuses __questStatus;
    private UICheckList __checkList;
    private bool __isInPosition = false;
    void Awake()
    {
        QuestStatus = QuestStatuses.None;
        __player = FindAnyObjectByType<FirstPersonMovement>();
        __cameraRotation = FindAnyObjectByType<FirstPersonLook>();
        __checkList = FindAnyObjectByType<UICheckList>();
        __winConditon = GetComponent<WinCondition>();
    }
    public void StartQuest()
    {
        if (!Money.GetInstance.WasteMoney(QuestPrice))
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

        __checkList.CompleteTask(this);
        __questStatus = QuestStatuses.Completed;

        QuestCompletionSound.Play();

        FinishGame.GetInstance.CheckFinishCondition();

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
public enum QuestStatuses
{
    Started, Completed, None, broken
}