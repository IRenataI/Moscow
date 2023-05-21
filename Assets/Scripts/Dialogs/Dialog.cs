using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public UnityEvent OnStartDialog;
    public UnityEvent OnEndDialog;
    public Canvas DialogCanvas;
    public void EnableDialogCanvas()
    {
        DialogCanvas.gameObject.SetActive(true);
        GameSystem.ChangeCursorMode(CursorLockMode.Confined);
    }
    public void DisableDialogCanvas()
    {
        DialogCanvas.gameObject.SetActive(false);
        GameSystem.ChangeCursorMode(CursorLockMode.Locked);
    }
}
