using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI QuestText;
    [SerializeField] private TextMeshProUGUI QuestTextIfStarted;
    [SerializeField] private TextMeshProUGUI QuestTextAfterCompletion;

    public UnityEvent OnStartDialog;
    public UnityEvent OnEndDialog;

    private DialogCanvas __dialogCanvasScript;
    private Canvas __dialogCanvas;
    private FirstPersonMovement __playerMovement;
    private FirstPersonLook __cameraRot;
    private Quest __quest;
    private CheckItem __checkItems;
    private void Awake()
    {
        __dialogCanvasScript = FindObjectOfType<DialogCanvas>();
        __dialogCanvas = __dialogCanvasScript.GetComponent<Canvas>();
        __playerMovement = FindObjectOfType<FirstPersonMovement>();
        __cameraRot = FindObjectOfType<FirstPersonLook>();
        __checkItems = GetComponent<CheckItem>();
        __quest = GetComponent<Quest>();

        if (__quest)
        {
            if (__checkItems && __quest.QuestStatus != QuestStatuses.Completed)
            {
                OnStartDialog.AddListener(() => __checkItems.Check());
            }
            OnEndDialog.AddListener(() => __quest.StartQuest());
            OnEndDialog.AddListener(() => __playerMovement.SetMovement(true));
        }
    }
    public void EnableDialogCanvas()
    {
        if (__checkItems && __quest.QuestStatus != QuestStatuses.Completed)
            __checkItems.Check();

        __dialogCanvas.enabled = true;
        __playerMovement.SetMovement(false);
        __cameraRot.SetCameraRotation(false);
        CursorManager.EnableCursor();

        switch (__quest?.QuestStatus)
        {
            case QuestStatuses.Started:
                __dialogCanvasScript.CreateDialogWithoutChoices(QuestTextIfStarted, this);
                break;
            case QuestStatuses.Completed:
                __dialogCanvasScript.CreateDialogWithoutChoices(QuestTextAfterCompletion, this);
                break;
            default:
                __dialogCanvasScript.CreateDialog(QuestText, this);
                break;
        }
        OnStartDialog?.Invoke();
        Debug.Log("DialogCanvas enaled. __quest.QuestStatus: " + __quest?.QuestStatus);   
    }

    public void DisableDialogCanvas()
    {
        __dialogCanvas.enabled = false;
        __playerMovement.SetMovement(true);
        __cameraRot.SetCameraRotation(true);
        CursorManager.EnableCursor();

        Debug.Log("DialogCanvas disable");
    }
}