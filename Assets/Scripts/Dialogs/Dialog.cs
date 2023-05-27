using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI QuestCheckListTask;
    public string AdditionInformation;
    public string[] QuestText;
    public UnityEvent OnStartDialog;
    public UnityEvent OnEndDialog;
    private bool __isAddedInformation = false;
    private DialogCanvas __dialogCanvas;
    private PlayerMovement __playrMovement;
    private void Awake()
    {
        __dialogCanvas = FindObjectOfType<DialogCanvas>();
        __playrMovement = FindObjectOfType<PlayerMovement>();       
    }
    public void EnableDialogCanvas()
    {
        __dialogCanvas.GetComponent<Canvas>().enabled = true;
        __dialogCanvas.CreateDialog(QuestText, this);

        GameSystem.ChangeCursorMode(CursorLockMode.Confined);

        OnStartDialog?.Invoke();
        Debug.Log("DialogCanvas enaled");

        __playrMovement.StopMovement();
    }
    public void DisableDialogCanvas()
    {
        __dialogCanvas.GetComponent<Canvas>().enabled = false;
        GameSystem.ChangeCursorMode(CursorLockMode.Locked);
        if (!__isAddedInformation)
        {
            QuestCheckListTask.text += " (" + AdditionInformation + ")";
            __isAddedInformation = true;
        }

        OnEndDialog?.Invoke();
    }
}
