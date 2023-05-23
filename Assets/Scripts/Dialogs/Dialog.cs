using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI QuestText;
    public string AdditionInformation;
    public UnityEvent OnStartDialog;
    public UnityEvent OnEndDialog;
    public Canvas DialogCanvas;
    public void EnableDialogCanvas()
    {
        DialogCanvas.gameObject.SetActive(true);
        GameSystem.ChangeCursorMode(CursorLockMode.Confined);

        OnStartDialog?.Invoke();
    }
    public void DisableDialogCanvas()
    {
        DialogCanvas.gameObject.SetActive(false);
        GameSystem.ChangeCursorMode(CursorLockMode.Locked);
        QuestText.text += " (" + AdditionInformation + ")";

        OnEndDialog?.Invoke();
    }
}
