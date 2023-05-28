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
    private FirstPersonMovement __player;
    private FirstPersonLook __cameraRotation;
    private WinCondition __winConditon;
    private BoxCollider __boxCollider;
    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<FirstPersonMovement>();
        __cameraRotation = FindAnyObjectByType<FirstPersonLook>();
        __winConditon = GetComponent<WinCondition>();
        __boxCollider = GetComponent<BoxCollider>();
    }
    public void StartQuest()
    {
        if (IsQuestCompleted)
        {
            __player.SetMovement(true);
            __cameraRotation.SetCameraRotation(true);
            Debug.Log("Quest already done");
            return;
        }

        __player.transform.position = QuestStartPosition.transform.position;

        __player.SetMovement(false);
        //__boxCollider.enabled = false;

        __questSystem.StartQuest(this);
        EventOnStart?.Invoke();
    }
    public void EndQuest()
    {
        __player.SetMovement(true);
        __cameraRotation.SetCameraRotation(true);

        //__boxCollider.enabled = true;

        EventOnEnd?.Invoke();
        __questSystem.EndQuest();
        IsQuestCompleted = true;

        Debug.Log("Quest completed: " + gameObject.name);
    }
    public void InterruptQuest()
    {
        EventOnInterrupt?.Invoke();

        __player.SetMovement(true);
        __cameraRotation.SetCameraRotation(true);

        __winConditon.ResetHittedTargets();

        //__boxCollider.enabled = true;

        Debug.Log("Quest interrupted");
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