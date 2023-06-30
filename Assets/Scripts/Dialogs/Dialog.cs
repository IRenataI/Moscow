using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public string AdditionInformation;
    public string[] QuestText;
    public string[] TextAfterCompletionQuest;
    public string[] TextIfQuestStarted;
    public string[] TextIfAdjacentQuestCompleted;
    public UnityEvent OnStartDialog;
    public UnityEvent OnEndDialog;
    private DialogCanvas __dialogCanvasScript;
    private Canvas __dialogCanvas;
    private FirstPersonMovement __playerMovement;
    private Quest __quest;
    private FirstPersonLook __cameraRot;
    private CheckItem __checkItems;
    private void Awake()
    {
        __dialogCanvasScript = FindObjectOfType<DialogCanvas>();
        __dialogCanvas = __dialogCanvasScript.GetComponent<Canvas>();
        __playerMovement = FindObjectOfType<FirstPersonMovement>();
        __cameraRot = FindObjectOfType<FirstPersonLook>();
        __checkItems = GetComponent<CheckItem>();
        __quest = GetComponent<Quest>();
    }
    public void EnableDialogCanvas()
    {
        if (!__quest)
        {
            Debug.Log("Quest doesnt found");
        }

        if (__checkItems && __quest.QuestStatus != Quest.QuestStatuses.Completed)
            __checkItems.Check();

        __dialogCanvas.enabled = true;
        __playerMovement.SetMovement(false);
        __cameraRot.SetCameraRotation(false);
        GameSystem.ChangeCursorMode(CursorLockMode.Confined);

        if (__quest && __quest.QuestStatus == Quest.QuestStatuses.Started)
        {
            __dialogCanvasScript.CreateDialogWithoutChoices(TextIfQuestStarted, this);
            Debug.Log("dialog if quest started");
            return;
        }
        if (__quest && __quest.QuestStatus == Quest.QuestStatuses.broken)
        {
            __dialogCanvasScript.CreateDialogWithoutChoices(TextIfAdjacentQuestCompleted, this);
            Debug.Log("dialog if quest broken");
            return;
        }
        if (__quest && __quest.QuestStatus == Quest.QuestStatuses.Completed)
        {
            __dialogCanvasScript.CreateDialogWithoutChoices(TextAfterCompletionQuest, this);
            Debug.Log("dialog if quest Completed");
            return;
        }
        __dialogCanvasScript.CreateDialog(QuestText, this);

        OnStartDialog?.Invoke();
        Debug.Log("DialogCanvas enaled. __quest.QuestStatus: " + __quest.QuestStatus);   
    }

    public void DisableDialogCanvas()
    {
        __dialogCanvas.enabled = false;
        GameSystem.ChangeCursorMode(CursorLockMode.Locked);
        __playerMovement.SetMovement(true);
        __cameraRot.SetCameraRotation(true);

        Debug.Log("DialogCanvas disable");
    }
}