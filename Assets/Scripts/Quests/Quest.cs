using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(WinCondition))]
[RequireComponent(typeof(QuestInteractable))]
public class Quest : MonoBehaviour
{
    public bool IsQuestCompleted = false;
    public UnityEvent EventOnStart;
    public UnityEvent EventOnEnd;
    private QuestSystem __questSystem;
    private PlayerMovement __player;
    private CameraRotation __cameraRotation;
    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        __questSystem = FindAnyObjectByType<QuestSystem>();
        __player = FindAnyObjectByType<PlayerMovement>();
        __cameraRotation = FindAnyObjectByType<CameraRotation>();
    }
    public void StartQuest()
    {
        __player.transform.position = Vector3.Lerp(__player.transform.position, 
            transform.position, 1f);
    
        __questSystem.StartQuest(this);
        EventOnStart?.Invoke();

        __player.StopMovement();
        //__cameraRotation.StopRotate();
    }
    public void EndQuest()
    {
        __questSystem.EndQuest();
        IsQuestCompleted = true;
        EventOnEnd?.Invoke();

        __player.ContinueMovement();
        __cameraRotation.StartRotate();

        Debug.Log("Quest completed");
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