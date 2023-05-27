using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    //public TextMeshProUGUI QuestCheckListTask;
    public string AdditionInformation;
    public string[] QuestText;
    public UnityEvent OnStartDialog;
    public UnityEvent OnEndDialog;
    private bool __isAddedInformation = false;
    private DialogCanvas __dialogCanvas;
    private FirstPersonMovement __playrMovement;
    private UICheckList __checkItem;
    private QuestSystem __questSystem;
    private void Awake()
    {
        __dialogCanvas = FindObjectOfType<DialogCanvas>();
        __playrMovement = FindObjectOfType<FirstPersonMovement>();
        __checkItem = FindObjectOfType<UICheckList>();
        __questSystem = FindObjectOfType<QuestSystem>();
    }
    public void EnableDialogCanvas()
    {
        __dialogCanvas.GetComponent<Canvas>().enabled = true;
        __dialogCanvas.CreateDialog(QuestText, this);

        GameSystem.ChangeCursorMode(CursorLockMode.Confined);

        __playrMovement.SetMovement(false);
        OnStartDialog?.Invoke();
        Debug.Log("DialogCanvas enaled");   
    }
    public void DisableDialogCanvas()
    {
        __dialogCanvas.GetComponent<Canvas>().enabled = false;
        GameSystem.ChangeCursorMode(CursorLockMode.Locked);        

        OnEndDialog?.Invoke();
        if (!__isAddedInformation)
        {
            int ind = __questSystem.GetCurrentQuestIndex;
            Debug.Log(__checkItem.transform.GetChild(ind).GetComponent<TextMeshProUGUI>()); 
            __checkItem.transform.GetChild(ind).GetComponent<TextMeshProUGUI>().text += " (" + AdditionInformation + ")";
            __isAddedInformation = true;
        }
    }
}
//QuestCheckListTask.text += " (" + AdditionInformation + ")";