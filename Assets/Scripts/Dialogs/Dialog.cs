using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public string AdditionInformation;
    public string[] QuestText;
    public string[] TextAfterCompletionQuest;
    public UnityEvent OnStartDialog;
    public UnityEvent OnEndDialog;
    public bool __isDialogAvailable = true;
    private bool __isAddedInformation = false;
    private DialogCanvas __dialogCanvasScript;
    private Canvas __dialogCanvas;
    private FirstPersonMovement __playrMovement;
    private UICheckList __checkItem;
    private QuestSystem __questSystem;
    private Quest __quest;
    private FirstPersonLook __cameraRot;
    private void Awake()
    {
        __dialogCanvasScript = FindObjectOfType<DialogCanvas>();
        __dialogCanvas = __dialogCanvasScript.GetComponent<Canvas>();
        __playrMovement = FindObjectOfType<FirstPersonMovement>();
        __cameraRot = FindObjectOfType<FirstPersonLook>();
        __checkItem = FindObjectOfType<UICheckList>();
        __questSystem = FindObjectOfType<QuestSystem>();
        __quest = GetComponent<Quest>();
    }
    public void EnableDialogCanvas()
    {
        __dialogCanvas.enabled = true;
        __playrMovement.SetMovement(false);
        __cameraRot.enabled = false;
        GameSystem.ChangeCursorMode(CursorLockMode.Confined);
        if (__quest && __quest.QuestStatus == Quest.QuestStatuses.Completed)
        {
            __dialogCanvasScript.CreateDialogWithoutChoices(TextAfterCompletionQuest, this);
            return;
        }
        if (!__quest)
        {
            Debug.Log("Quest doesnt found");
        }
        __dialogCanvasScript.CreateDialog(QuestText, this);

        OnStartDialog?.Invoke();
        Debug.Log("DialogCanvas enaled. " + __quest.QuestStatus);   
    }

    public void DisableDialogCanvas()
    {
        __dialogCanvas.enabled = false;
        GameSystem.ChangeCursorMode(CursorLockMode.Locked);
        __playrMovement.SetMovement(true);
        __cameraRot.enabled = true;

        Debug.Log("DialogCanvas disable");
    }
    public void AddAdditionInfo()
    {
        if (!__isAddedInformation)
        {
            int ind = __questSystem.GetIndexByQuest(GetComponent<Quest>());
            if (ind > -1)
                __checkItem.transform.GetChild(ind).GetComponent<TextMeshProUGUI>().text += " (" + AdditionInformation + ")";
            else
                Debug.Log("ind < 0");
            __isAddedInformation = true;
        }
    }
}
//QuestCheckListTask.text += " (" + AdditionInformation + ")";
//__checkItem.transform.GetChild(ind).GetComponent<TextMeshProUGUI>().text += " (" + AdditionInformation + ")";
